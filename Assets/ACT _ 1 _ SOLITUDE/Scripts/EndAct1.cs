using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Act1EndSequence : MonoBehaviour
{

    //this script should be for the play screen, yes or no quesiton at the start, fade into captured image and the act 2 transiion
    //game manager should just call functions from this script

    [SerializeField] private CanvasGroup actOverPanel;
    [SerializeField] private float fadeDuration = 2f;

    public void Play()
    {
        StartCoroutine(FadeInPanel());
    }

    private IEnumerator FadeInPanel()
    {
        actOverPanel.gameObject.SetActive(true);
        actOverPanel.alpha = 0f;

        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;
            actOverPanel.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            yield return null;
        }

        actOverPanel.alpha = 1f;
        Time.timeScale = 0f;
    }
}