using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Score")]
    public int score = 0;
    public TMP_Text scoreText;

    [Header("Ring Count")]
    public int ringCount = 0;
    public TMP_Text ringsText;

    [Header("Health")]
    public int healthRings = 3;
    public TMP_Text healthPercentText;

    [Header("HUD")]
    public GameObject hudPanel;   // drag your Score/Rings/Health parent here

    [Header("Game Over UI")]
    public GameObject gameOverPanel;

    [Header("Win UI")]
    public GameObject winPanel;
    public TMP_Text scoreResultsText;
    public TMP_Text ringsResultText;

    [Header("Finish Effects")]
    public GameObject finishLineVisual;
    public ParticleSystem finishParticles;

    private bool isGameOver = false;
    private bool isWin = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ringCount = 0;
        healthRings = 3;
        UpdateUI();

        if (hudPanel != null)
            hudPanel.SetActive(true);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (winPanel != null)
            winPanel.SetActive(false);

        if (finishParticles != null)
        {
            finishParticles.gameObject.SetActive(true);
            finishParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

        Time.timeScale = 1f;
    }

    public void AddScore(int amount)
    {
        if (isGameOver || isWin) return;

        score += amount;
        UpdateUI();
    }

    public void AddRings(int amount)
    {
        if (isGameOver || isWin) return;

        ringCount += amount;

        if (ringCount < 0)
            ringCount = 0;

        UpdateUI();
    }

    public void TakeDamage()
    {
        if (isGameOver || isWin) return;

        if (CameraShake.Instance != null)
            CameraShake.Instance.Shake(0.2f);

        healthRings--;
        ringCount -= 2;

        if (ringCount < 0)
            ringCount = 0;

        if (healthRings < 0)
            healthRings = 0;

        UpdateUI();

        if (healthRings <= 0)
            GameOver();
    }

    public void WinGame()
    {
        if (isGameOver || isWin) return;

        isWin = true;

        if (finishLineVisual != null)
            finishLineVisual.SetActive(false);

        if (finishParticles != null)
        {
            finishParticles.transform.position = new Vector3(
                finishParticles.transform.position.x,
                finishParticles.transform.position.y,
                finishLineVisual != null ? finishLineVisual.transform.position.z : finishParticles.transform.position.z
            );

            finishParticles.Play();
        }

        // Hide top-left HUD
        if (hudPanel != null)
            hudPanel.SetActive(false);

        // Fill win panel text
        if (scoreResultsText != null)
            scoreResultsText.text = "Score: " + score;

        if (ringsResultText != null)
            ringsResultText.text = "Rings: " + ringCount;

        if (winPanel != null)
            winPanel.SetActive(true);

        Invoke(nameof(FreezeGame), 1.0f);
    }

    void FreezeGame()
    {
        Time.timeScale = 0f;
    }

    void GameOver()
    {
        isGameOver = true;

        if (hudPanel != null)
            hudPanel.SetActive(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (ringsText != null)
            ringsText.text = "Rings: " + ringCount;

        if (healthPercentText != null)
        {
            float percent = (healthRings / 3f) * 100f;
            healthPercentText.text = "Health: " + percent.ToString("F1") + "%";
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public bool IsGameOver()
    {
        return isGameOver || isWin;
    }
}