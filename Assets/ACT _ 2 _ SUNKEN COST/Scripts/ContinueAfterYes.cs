using System.Collections;
using UnityEngine;

public class ContinueAfterYes : MonoBehaviour
{
    public UIFade uiFade;
    public GameObject continueUIPage;
    public GameObject stillFishingFrame;
    public GameObject inbetweenFishingSequence;

    public float waitBeforeInbetween = 3f;

    public void OnContinuePressed()
    {
        StartCoroutine(ContinueSequence());
    }

    IEnumerator ContinueSequence()
    {
        //continueUIPage.SetActive(false);
        yield return StartCoroutine(uiFade.FadeOut());

        yield return new WaitForSeconds(waitBeforeInbetween);

        stillFishingFrame.SetActive(false);
        inbetweenFishingSequence.SetActive(true);

     
    }


  
}
