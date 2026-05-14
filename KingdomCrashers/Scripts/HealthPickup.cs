using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [Range(0f, 1f)]
    public float healPercent = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                int healAmount = Mathf.RoundToInt(playerHealth.maxHealth * healPercent);

                playerHealth.Heal(healAmount);

                Debug.Log("Healed player for " + healAmount);

                Destroy(gameObject);
            }
        }
    }
}