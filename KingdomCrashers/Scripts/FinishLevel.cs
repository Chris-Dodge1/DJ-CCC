using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public GameObject winPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("LEVEL COMPLETE!");

            if (winPanel != null)
            {
                winPanel.SetActive(true);
            }

            Time.timeScale = 0f;
        }
    }
}