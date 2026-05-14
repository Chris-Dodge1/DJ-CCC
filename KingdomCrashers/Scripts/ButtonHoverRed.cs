using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHoverRed : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI buttonText;

    private Color normalColor = Color.white;
    private Color hoverColor = Color.red;

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