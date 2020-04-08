using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasFade : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void fadeOut(float aDuration = 1f)
    {
        StartCoroutine(FadeOut(aDuration));
    }

    public void fadeIn(float aDuration = 1f)
    {
        StartCoroutine(FadeIn(aDuration));
    }

    private IEnumerator FadeOut(float aD)
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        float time = aD;
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }

    private IEnumerator FadeIn(float aD, Button aB = null)
    {
        float time = aD;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / time;
            yield return null;
        }
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}