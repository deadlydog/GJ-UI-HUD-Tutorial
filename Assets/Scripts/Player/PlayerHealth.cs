using System;
using System.Collections;
using System.Collections.Generic;
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
