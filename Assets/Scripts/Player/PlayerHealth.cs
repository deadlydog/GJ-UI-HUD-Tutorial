using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;

    public static EventHandler<float> HealthChanged;

    private int health;
    public int Health
    {
        get { return health; }
        set 
        {  
            health = (int)Mathf.Clamp(value, 0, 100);

            Debug.Log($"Health is {health}");
            if (health <= 0)
            {
                Debug.Log("Health is 0 so returning to Main Menu");
                SceneManager.LoadScene("Main Menu");
            }

            HealthChanged?.Invoke(this, health / 100f);
        }
    }

    private void OnEnable()
    {
        Health = startingHealth;
    }
}
