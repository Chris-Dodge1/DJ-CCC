using UnityEngine;
using TMPro;

public class PlayerGold : MonoBehaviour
{
    public int gold = 0;

    [Header("UI")]
    public TMP_Text goldText;

    void Start()
    {
        UpdateUI();
    }

    public void AddGold(int amount)
    {
        gold += amount;
        UpdateUI();

        Debug.Log("Gold: " + gold);
    }

    void UpdateUI()
    {
        if (goldText != null)
            goldText.text = gold.ToString();
    }
}