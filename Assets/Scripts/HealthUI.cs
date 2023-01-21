using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image healthFill;
    
    private void OnEnable()
    {
        PlayerHealth.HealthChanged += HealthChanged;
    }

    private void OnDisable()
    {
        PlayerHealth.HealthChanged -= HealthChanged;
    }

    private void HealthChanged(object sender, float health)
    {
        healthFill.fillAmount = health;
    }
}
