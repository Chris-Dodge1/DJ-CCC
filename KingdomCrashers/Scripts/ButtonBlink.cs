using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonBlink : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float blinkSpeed = 0.6f;

    private Image buttonImage;
    private Coroutine blinkRoutine;
    private Color originalColor;

    void Awake()
    {
        buttonImage = GetComponent<Image>();
        originalColor = buttonImage.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (blinkRoutine != null)
            StopCoroutine(blinkRoutine);

        blinkRoutine = StartCoroutine(Blink());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (blinkRoutine != null)
            StopCoroutine(blinkRoutine);

        buttonImage.color = originalColor;
    }

    IEnumerator Blink()
    {
        while (true)
        {
            buttonImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.25f);
            yield return new WaitForSeconds(blinkSpeed);

            buttonImage.color = originalColor;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
}