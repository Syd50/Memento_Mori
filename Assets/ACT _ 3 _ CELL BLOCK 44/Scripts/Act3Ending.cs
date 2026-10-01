using UnityEngine;
using System.Collections;

public class Act3Ending : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudio;
    [SerializeField] private CanvasGroup finalImage;
    [SerializeField] private float finalImageFadeDuration = 2f;

    private bool endingStarted = false;

    private void Awake()
    {
        if (finalImage != null)
        {
            finalImage.alpha = 0f;
            finalImage.gameObject.SetActive(false);
        }
    }

    public void FreezeAndShowFinalImage()
    {
        if (endingStarted == false)
        {
            endingStarted = true;
            StartCoroutine(FinalEndingSequence());
        }
    }

    private IEnumerator FinalEndingSequence()

    {

        yield return new WaitForSeconds(8f);


        if (musicAudio != null)
        {
            musicAudio.Stop();
        }

        Time.timeScale = 0f;

        if (finalImage != null)
        {
            finalImage.gameObject.SetActive(true);
            finalImage.alpha = 0f;

            float timer = 0f;

            while (timer < finalImageFadeDuration)
            {
                timer += Time.unscaledDeltaTime;

                finalImage.alpha = Mathf.Lerp(
                    0f,
                    1f,
                    timer / finalImageFadeDuration
                );

                yield return null;
            }

            finalImage.alpha = 1f;
        }
    }
}
