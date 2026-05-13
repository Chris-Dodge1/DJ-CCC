using UnityEngine;

public class RingCollectible : MonoBehaviour
{
    public int ringValue = 1;
    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (!other.CompareTag("Player")) return;

        collected = true;

        GameManager gm = FindFirstObjectByType<GameManager>();
        if (gm != null)
        {
            gm.AddRings(ringValue);
        }

        Destroy(gameObject);
    }
}