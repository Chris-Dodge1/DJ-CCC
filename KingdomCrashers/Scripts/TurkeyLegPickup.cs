using UnityEngine;

public class TurkeyLegPickup: MonoBehaviour
{
    public int healAmount = 15;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }

            Destroy(gameObject);
        }
    }
}