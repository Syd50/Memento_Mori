using System.Collections;
using UnityEngine;

public class UIFade : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public float fadeTime = 0.05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        
    }

   public IEnumerator FadeIn()
    {
        canvasGroup.gameObject.SetActive(true);

        float t = 0;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / fadeTime);
            yield return null;
        }

        canvasGroup.alpha = 1;
        canvasGroup.interactable =true;
        canvasGroup.blocksRaycasts=true;
        
    }

    public IEnumerator FadeOut()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        float t = 0;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / fadeTime);
            yield return null;
        }

        canvasGroup.alpha = 0;
        canvasGroup.gameObject.SetActive(false);
    }
}
