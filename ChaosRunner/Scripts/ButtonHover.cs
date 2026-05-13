using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image img;
    private Coroutine blinkRoutine;
    private Color originalColor;
    private bool hovering = false;

    void Start()
    {
        img = GetComponent<Image>();
        originalColor = img.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
        if (blinkRoutine == null)
            blinkRoutine = StartCoroutine(Blink());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
        if (blinkRoutine != null)
        {
            StopCoroutine(blinkRoutine);
            blinkRoutine = null;
        }

        img.color = originalColor;
    }

    IEnumerator Blink()
    {
        while (hovering)
        {
            img.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.35f);
            yield return new WaitForSeconds(0.2f);

            img.color = originalColor;
            yield return new WaitForSeconds(0.2f);
        }
    }
}