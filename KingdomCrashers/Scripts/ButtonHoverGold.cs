using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHoverGold : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI buttonText;

    private Color normalColor = Color.white;
    private Color hoverColor = new Color(1f, 0.84f, 0f);

    void Start()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        buttonText.color = normalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = normalColor;
    }
}
