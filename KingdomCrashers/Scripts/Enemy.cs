using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 15;
    public int currentHealth;

    [Header("XP Reward")]
    public int xpReward = 25;

    [Header("Gold Drops")]
    public GameObject goldBagPrefab;
    public int goldBagsToDrop = 1;

    [Header("Health Drop")]
    public GameObject turkeyLegPrefab;
    public float turkeyLegDropChance = 0.35f;

    [Header("Turkey Leg Scatter")]
    public float turkeyLegMinDistance = 4f;
    public float turkeyLegMaxDistance = 7f;
    public float turkeyLegYOffset = 0.7f;

    [Header("Death")]
    public Sprite deadSprite;
    public float destroyDelay = 2f;

    private bool isDead = false;

    private SpriteRenderer sr;
    private Collider2D[] colliders;
    private Rigidbody2D rb;
    private EnemyAI enemyAI;

    void Start()
    {
        currentHealth = maxHealth;

        sr = GetComponent<SpriteRenderer>();
        colliders = GetComponents<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<EnemyAI>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        Debug.Log(gameObject.name + " hit! HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        GiveXP();
        DropGold();
        DropTurkeyLeg();

        if (enemyAI != null)
            enemyAI.enabled = false;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        foreach (Collider2D col in colliders)
        {
            col.enabled = false;
        }

        Animator anim = GetComponent<Animator>();

        if (anim != null)
            anim.enabled = false;

        if (deadSprite != null)
            sr.sprite = deadSprite;

        transform.position += new Vector3(0f, -2.5f, 0f);

        StartCoroutine(BlinkAndDestroy());
    }

    void DropGold()
    {
        if (goldBagPrefab == null) return;

        for (int i = 0; i < goldBagsToDrop; i++)
        {
            Vector3 dropPosition = transform.position + new Vector3(
                Random.Range(-0.5f, 0.5f),
                0.5f,
                0f
            );

            Instantiate(goldBagPrefab, dropPosition, Quaternion.identity);
        }
    }

    void DropTurkeyLeg()
    {
        if (turkeyLegPrefab == null) return;

        if (Random.value <= turkeyLegDropChance)
        {
            float direction = Random.value < 0.5f ? -1f : 1f;
            float distance = Random.Range(turkeyLegMinDistance, turkeyLegMaxDistance);

            Vector3 dropPosition = transform.position + new Vector3(
                direction * distance,
                turkeyLegYOffset,
                0f
            );

            Instantiate(turkeyLegPrefab, dropPosition, Quaternion.identity);
        }
    }

    IEnumerator BlinkAndDestroy()
    {
        yield return new WaitForSeconds(destroyDelay);

        float blinkDuration = 2f;
        float blinkSpeed = 0.15f;
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

    void GiveXP()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            PlayerXP playerXP = player.GetComponent<PlayerXP>();

            if (playerXP != null)
            {
                playerXP.AddXP(xpReward);
                Debug.Log("Player gained " + xpReward + " XP!");
            }
        }
    }
}