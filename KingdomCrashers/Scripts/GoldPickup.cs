using System.Collections;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int goldValue = 5;

    [Header("Disappear Settings")]
    public float waitBeforeBlink = 15f;
    public float blinkDuration = 1.5f;
    public float blinkSpeed = 0.15f;

    private SpriteRenderer sr;
    private bool collected = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(BlinkThenDisappear());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;
        if (!other.CompareTag("Player")) return;

        PlayerGold playerGold = other.GetComponent<PlayerGold>();

        if (playerGold != null)
        {
            collected = true;
            playerGold.AddGold(goldValue);
            Destroy(gameObject);
        }
    }

    IEnumerator BlinkThenDisappear()
    {
        yield return new WaitForSeconds(waitBeforeBlink);

        float timer = 0f;

        while (timer < blinkDuration)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(blinkSpeed);

            sr.enabled = true;
            yield return new WaitForSeconds(blinkSpeed);

            timer += blinkSpeed * 2;
        }

        Destroy(gameObject);
    }
}