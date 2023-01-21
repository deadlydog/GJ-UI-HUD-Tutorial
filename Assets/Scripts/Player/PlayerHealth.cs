using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;

    public int health;

    private void OnEnable()
    {
        health = startingHealth;
    }
}
