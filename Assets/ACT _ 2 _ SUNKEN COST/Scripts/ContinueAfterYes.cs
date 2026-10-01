using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueAfterYes : MonoBehaviour
{
    public UIFade uiFade;
    public GameObject continueUIPage;
    public GameObject stillFishingFrame;
    public GameObject inbetweenFishingSequence;

    public GameObject fallingSequence;

    public SwitchCamera switchCamera;

    public Animator[] cloudAnimators;

    public float waitBeforeInbetween = 1.5f;
    public float waitBeforeFalling = 1f;

    public Transform cloudsParent;

    public float waitBeforeQuoteOneCam = 1f;

    //line drawing animation
    public Animator cloudEffectAnimator;

    //camera target falling as soon as starts
    public Animator fallingTargetAnimator;

    //everything moving at once
    //try give separate timings for 'AFTER' inbetween anim?
    public float waitAfterCloudEffect = 1f;
    public float waitAfterFallStarts = 0.5f;
    public float waitAfterCloudsMove = 0.5f;

    public Animator quoteAnimator;

    //SFX
    //casting the line - plays onthe inbetween anim
    public AudioSource fishingAudio;
    public AudioSource fallingAudio;

    //SWITCHING SCENES

    public string nextSceneName;
    public float timeOnQuoteCamera = 14f;

    //adding this brought other CLICK YES UI screen
    //public float fadeTime = 1f;
    //maybe make separate fading script which will use a fade ui screen that doesnt destroy on load?


    private void Start()
    {
        cloudAnimators = cloudsParent.GetComponentsInChildren<Animator>();

        foreach (Animator anim in cloudAnimators)
            anim.enabled = false;

        //cloud anim should start later
        if (cloudEffectAnimator != null)
            cloudEffectAnimator.enabled = false;

        fallingTargetAnimator.enabled = false;

        quoteAnimator.enabled = false;

    }

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
        //delay a little
        yield return new WaitForSeconds(2f);
        //SFX right after casting line plays
        fishingAudio.Play();

        yield return new WaitForSeconds(waitBeforeFalling);

        //switch the two
        //inbetweenFishingSequence.SetActive(false);

        //add cloud line drawing anm
        //CLOUDS EFFECT FIRST
        cloudEffectAnimator.enabled = true;

        //wait a bit
        yield return new WaitForSeconds(waitAfterCloudEffect);

        //cloudEffectAnimator.gameObject.SetActive(false);
        inbetweenFishingSequence.SetActive(false);

        //start falling anim
        fallingSequence.SetActive(true);

        fallingTargetAnimator.enabled = true;

        // Play falling sound
        fallingAudio.Play();

        //wait 1 sec after fall starts
        yield return new WaitForSeconds(waitAfterFallStarts);

        cloudEffectAnimator.gameObject.SetActive(false);

        foreach (Animator anim in cloudAnimators)
        {
            //cloudAnimator.SetTrigger("MoveCloud");
            anim.enabled = true;
        }


        //wait before changing camera
        yield return new WaitForSeconds(waitAfterCloudsMove);
        switchCamera.SwitchingToFalling();

        yield return new WaitForSeconds(waitBeforeQuoteOneCam);
        switchCamera.SwitchToQuoteOne();

        quoteAnimator.enabled = true;

        //stay on the quote cam for about 6 seconds??
        yield return new WaitForSeconds(timeOnQuoteCamera);

        //fadee out

        //Or this one fades from alpha 0 -1 
        //and ACT 3 goes from 1-0
        //yield return StartCoroutine(uiFade.FadeIn());

        SceneManager.LoadScene(nextSceneName);


    }


  
}
