using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int healthGiven;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.attachedRigidbody == null) {return;}

        PlayerHealth health = collision.collider.attachedRigidbody.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.Health += healthGiven;
            Destroy(gameObject);
        }
        
        Ground ground = collision.collider.attachedRigidbody.GetComponent<Ground>();

        if (ground != null)
        {
            Destroy(gameObject);
        }
    }
}
