using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.attachedRigidbody == null) {return;}

        PlayerCoins coins = collision.collider.attachedRigidbody.GetComponent<PlayerCoins>();

        if (coins != null)
        {
            coins.Coins++;
            Destroy(gameObject);
        }
        
        Ground ground = collision.collider.attachedRigidbody.GetComponent<Ground>();

        if (ground != null)
        {
            Destroy(gameObject);
        }
    }
}
