using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Reset Settings")]
    public float resetDelay = 2f; // time after last hit before reset

    private float lastHitTime;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // If enough time has passed since last hit, reset HP
        if (currentHealth < maxHealth && Time.time - lastHitTime >= resetDelay)
        {
            ResetHealth();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        lastHitTime = Time.time; // track when last hit happened

        Debug.Log(gameObject.name + " took " + damage + " damage. HP: " + currentHealth);
    }

    void ResetHealth()
    {
        currentHealth = maxHealth;
        Debug.Log(gameObject.name + " reset HP after not being hit.");
    }
}