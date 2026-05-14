using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerXP : MonoBehaviour
{
    [Header("Level Settings")]
    public int level = 1;
    public int currentXP = 0;
    public int xpToNextLevel = 100;

    [Header("UI")]
    public Image xpFill;
    public TMP_Text levelText;

    void Start()
    {
        UpdateXPUI();
    }

    public void AddXP(int amount)
    {
        currentXP += amount;

        while (currentXP >= xpToNextLevel)
        {
            currentXP -= xpToNextLevel;
            level++;
            xpToNextLevel += 50;
        }

        UpdateXPUI();
    }

    void UpdateXPUI()
    {
        if (xpFill != null)
        {
            xpFill.fillAmount = (float)currentXP / xpToNextLevel;
        }

        if (levelText != null)
        {
            levelText.text = level.ToString();
        }
    }
}