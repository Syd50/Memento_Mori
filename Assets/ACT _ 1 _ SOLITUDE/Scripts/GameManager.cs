using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //ACT 1
    public GameObject gameOverPanel;
    public Image fadeImage;
    public float fadeDuration = 2f;

    //ACT 3
    [SerializeField] private float exitDelay = 2f;
    [SerializeField] private GameObject filmGrain;
    private CanvasGroup grainCanvasGroup;
    private bool hasExited = false;

    //Film borders
    [SerializeField] private RectTransform topBorder;
    [SerializeField] private RectTransform bottomBorder;
    [SerializeField] private float borderSlideDuration = 1.5f;
    [SerializeField] private float targetBorderHeight = 50f;

    //PNG sequence - THE END
    [SerializeField] private GameObject theEndSequenceObject;

    private void Awake()
    {
        Instance = this;

        grainCanvasGroup = filmGrain.GetComponent<CanvasGroup>();

        if (grainCanvasGroup == null)
        {
            Debug.Log("Missing Canvas Group component on " + filmGrain.name);
        }
        else
        {
            grainCanvasGroup.alpha = 0f; //starts off hidden
        }

        SlideBorders();

        // turn off at start
        if (theEndSequenceObject != null)
        {
            theEndSequenceObject.SetActive(false);
        }
    }

    private void SlideBorders()
    {
        if (topBorder != null && bottomBorder != null)
        {
            //posititon outside of screen
            topBorder.anchoredPosition = new Vector2(0, targetBorderHeight);
            bottomBorder.anchoredPosition = new Vector2(0, -targetBorderHeight);
        }
    }

    public void GameOver()
    {
        MonsterSpawner spawner = FindFirstObjectByType<MonsterSpawner>();
        if (spawner != null)
        {
            spawner.enabled = false;
        }

        ObjectPoolRoad[] roads = Object.FindObjectsByType<ObjectPoolRoad>(FindObjectsSortMode.None);
        foreach (ObjectPoolRoad road in roads)
        {
            road.enabled = false;
        }

        StartCoroutine(FadeToGameOver());
    }

    private IEnumerator FadeToGameOver()
    {
        float timer = 0f;
        Color colour = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            colour.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = colour;
            yield return null;
        }

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayerReachedExit()
    {
        Debug.Log("EXIT REACHED");

        if (hasExited) return;
        hasExited = true;

        StartCoroutine(ExitSequence());
    }

    private IEnumerator ExitSequence()
    {
        Debug.Log("EXIT SEQUENCE STARTED");

        yield return new WaitForSeconds(exitDelay);

        // spawn and road stop when ui starts
        MonsterSpawner spawner = FindFirstObjectByType<MonsterSpawner>();
        if (spawner != null) spawner.enabled = false;

        ObjectPoolRoad[] roads = Object.FindObjectsByType<ObjectPoolRoad>(FindObjectsSortMode.None);
        foreach (ObjectPoolRoad road in roads) road.enabled = false;

        // slide after the delay
        if (topBorder != null && bottomBorder != null)
        {
            StartCoroutine(SlideBordersIn());
        }

        if (grainCanvasGroup != null)
        {
            grainCanvasGroup.alpha = 0f;
            filmGrain.SetActive(true);

            float timer = 0f;
            while (timer < exitDelay)
            {
                timer += Time.deltaTime;
                grainCanvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
                yield return null;
            }

            grainCanvasGroup.alpha = 1f;
        }
        else
        {
            Debug.LogError("Cannot fade: grainCanvasGroup is missing");
        }

        // no timescele here 
        // This stops it from freezing the SlideBordersIn loop early
    }

    private IEnumerator SlideBordersIn()
    {
        float timer = 0f;

        // Starting positions
        Vector2 topStart = new Vector2(0, targetBorderHeight);
        Vector2 toppEnd = Vector2.zero;

        Vector2 bottomStart = new Vector2(0, -targetBorderHeight);
        Vector2 bottomEnd = Vector2.zero;

        while (timer < borderSlideDuration)
        {
            // using unscaledDeltaTime - this handles animation safely even if time scale changes
            timer += Time.unscaledDeltaTime;
            float t = timer / borderSlideDuration;

            t = Mathf.SmoothStep(0f, 1f, t);

            topBorder.anchoredPosition = Vector2.Lerp(topStart, toppEnd, t);
            bottomBorder.anchoredPosition = Vector2.Lerp(bottomStart, bottomEnd, t);

            yield return null;
        }

        //snap alignment
        topBorder.anchoredPosition = toppEnd;
        bottomBorder.anchoredPosition = bottomEnd;

        // triggers instantly when borders hit  destination height positions
        if (theEndSequenceObject != null)
        {
            theEndSequenceObject.SetActive(true);
            Debug.Log("Border DONE ");

            // pause bg 
            Time.timeScale = 0f;
        }
    }
}



