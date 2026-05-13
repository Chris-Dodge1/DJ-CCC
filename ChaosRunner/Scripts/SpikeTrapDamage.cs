using UnityEngine;

public class SpikeTrapDamage : MonoBehaviour
{
    private bool hasDamaged = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasDamaged) return;
        if (!other.CompareTag("Player")) return;

        hasDamaged = true;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.TakeDamage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasDamaged = false;
        }
    }
}