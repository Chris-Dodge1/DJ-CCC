using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    public Image healthFill;

    [Header("Death Sprite")]
    public Sprite deadSprite;
    public float deathYOffset = -1.5f;

    [Header("Game Over")]
    public GameObject gameOverPanel;

    private bool isDead = false;

    private SpriteRenderer sr;
    private Animator anim;
    private Rigidbody2D rb;
    private Collider2D[] colliders;

    void Start()
    {
        currentHealth = maxHealth;

        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        colliders = GetComponents<Collider2D>();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateHealthUI();

        Debug.Log("Player Health: " + currentHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return;

        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();

        Debug.Log("Player took " + damageAmount + " damage. HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        if (isDead) return;

        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();

        Debug.Log("Player healed for " + healAmount + ". HP: " + currentHealth);
    }

    void UpdateHealthUI()
    {
        if (healthFill != null)
        {
            healthFill.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    void Die()
    {
        isDead = true;

        Debug.Log("Player died.");

        if (anim != null)
            anim.enabled = false;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        foreach (Collider2D col in colliders)
        {
            col.enabled = false;
        }

        if (deadSprite != null && sr != null)
        {
            sr.sprite = deadSprite;
        }

        transform.position += new Vector3(0f, deathYOffset, 0f);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}