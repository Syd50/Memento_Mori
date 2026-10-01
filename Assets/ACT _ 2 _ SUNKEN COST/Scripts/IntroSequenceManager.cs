using System.Collections;
using UnityEngine;

public class IntroSequenceManager : MonoBehaviour
{

    public RectTransform swipeCloud;
    public GameObject continueUIPage;

    public float speed = 500f;
    public float startX = -1600f;
    public float endX = 1200f;
    public float delayAfterCloud = 1f;
    public UIFade uiFade;

    private bool finished;


    // turn start into a co routine?
   void Start()
    {
        continueUIPage.SetActive(false);
        //yield return StartCoroutine(uiFade.FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        if (finished) return;

        swipeCloud.anchoredPosition += Vector2.right * speed * Time.deltaTime;

        if (swipeCloud.anchoredPosition.x >= endX)
        {
            finished = true;
            StartCoroutine(ShowContinuePage());
        }
    }

    IEnumerator ShowContinuePage()
    {
        swipeCloud.gameObject.SetActive(false);

        yield return new WaitForSeconds (delayAfterCloud);

        //continueUIPage.SetActive (true);
        yield return StartCoroutine(uiFade.FadeIn());
    }
}
