using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private bool hasBeenHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenHit) return;

        if (other.CompareTag("Bullet"))
        {
            hasBeenHit = true;

            Destroy(other.gameObject);
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Player"))
        {
            hasBeenHit = true;

            if (GameManager.Instance != null)
                GameManager.Instance.TakeDamage();

            if (CameraShake.Instance != null)
                CameraShake.Instance.Shake(0.2f);

            Destroy(gameObject);
        }
    }
}