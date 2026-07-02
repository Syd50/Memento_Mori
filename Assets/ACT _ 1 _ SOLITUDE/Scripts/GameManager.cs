using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //public GameObject startPanel;

    //ACT 1
    public GameObject gameOverPanel;
    public Image fadeImage;

    public float fadeDuration = 2f;
    //need to freeze player movement after collision with monster
    //public BikeController bikeController;   ----------------------------------- Bike isnt moving, ROAD IS

    //ACT 3
    [SerializeField] private float exitDelay = 2f;

    [SerializeField] private GameObject filmGrain;
    //holds png sequence, animator and cangvas group
     private CanvasGroup grainCanvasGroup;
    private bool hasExited = false;

    //Film borders
    [SerializeField] private RectTransform topBorder;
    [SerializeField] private RectTransform bottomBorder;
    [SerializeField] private float borderSlideDuration = 1.5f;
    [SerializeField] private float targetBorderHeight = 50f;

    //PNG sequence - THE END
    [SerializeField] private GameObject theEndSequenceObject;
    //[SerializeField] private float sequenceDelay = 8f;



    //ACT 1
    private void Awake()
    {
        //store as a static variable called Instance
        //Singleton - makes sure class only has one instance in entire game, everyone has global access to it
        //ANALOGY - TV remote. There is only ONE, everyone uses the same one to contorl the TV. Don't want 5 remotes controlling same TV (singleton prevents this)
        //other scripts will be able to access using class name - instance
        Instance = this;

        //grab component before start to try forcce it to work

        grainCanvasGroup = filmGrain.GetComponent<CanvasGroup>();

        if (grainCanvasGroup == null)
        {
            Debug.Log("Missing Canvas Group component on " + filmGrain.name);
           
        }
        else
        {
            grainCanvasGroup.alpha = 0f; //starts off hidden
        }
        //lets hide the border instead of a fade
        SlideBorders();
    }

    private void SlideBorders()
    {
        if (topBorder !=null && bottomBorder !=null)
        {
            //position outside of the screen
            topBorder.anchoredPosition = new Vector2(0, targetBorderHeight);
            bottomBorder.anchoredPosition = new Vector2(0, -targetBorderHeight);
            //this needs to be in one of he coroutines below 

            //mayvbe make slide duration the same as the fade duration

        }
    }


    //stop road immediately?
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
        //bikeController.enabled = false;
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
        //pause entire game by stopping unity's time system
        // 0 = paused
        // 1 = normal speed
        Time.timeScale = 0f;
    }

    //ACT 3

    public void PlayerReachedExit()
    {
        Debug.Log("EXIT REACHED");

        if (hasExited) return;
        hasExited = true;

        StartCoroutine(ExitSequence());


        //PNG The End
        //StartCoroutine(PlayEndSequenceAfterDelay());
    }


    //exit coroutine for ACT  3

    //change to fade in WHEN player lands
    private IEnumerator ExitSequence()
    {

        Debug.Log("EXIT SEQUENCE STARTED");

        //just wait for player to land instead??

        yield return new WaitForSeconds(exitDelay);

        //start sldiing after the de;ay
        if(topBorder !=null && bottomBorder != null)
        {
            StartCoroutine(SlideBordersIn());
        }

        if (grainCanvasGroup != null)
        {
            //try forcing to be zero so it doesnt flash weirdly
            grainCanvasGroup.alpha = 0f;
            filmGrain.SetActive(true);

            //dont go all the way to 1, its a light  over lay
            float timer = 0f;
            while (timer < exitDelay)
            {
                timer += Time.deltaTime;
                grainCanvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
                yield return null;
            }

            //finish at exactly 0.7
            grainCanvasGroup.alpha = 1f;
        }
        else
        {
            Debug.LogError("Cannot fade: grainCanvasGroup is missing");
        }

            ////film grain fade
            //grainCanvasGroup.alpha = 0f;
            //filmGrain.SetActive(true);

            ////fade pngs

            //float timer = 0f;
            ////Color colour = fadeImage.color;

            //while (timer < fadeDuration)
            //{
            //    timer += Time.deltaTime;
            //    grainCanvasGroup.alpha = Mathf.Lerp(0f, 0.7f, timer / fadeDuration);
            //    //fadeImage.color = colour;
            //    yield return null;
            //}

            //ending panel, change to png sequence later


            //pause gmaeplay
            Time.timeScale = 0f;

    }


    //private IEnumerator PlayEndSequenceAfterDelay()
    //{
    //    yield return new WaitForSeconds(sequenceDelay);

    //    if (theEndSequenceObject != null)
    //    {
    //        theEndSequenceObject.SetActive(true);
    //        Debug.Log("The End PNG sequence started");
    //    }
    //}

    private IEnumerator SlideBordersIn()
    {
        float timer = 0f;

        //startinmg pos
        Vector2 topStart = new Vector2(0, targetBorderHeight);
        Vector2 toppEnd = Vector2.zero;

        Vector2 bottomStart = new Vector2(0, -targetBorderHeight);
        Vector2 bottomEnd = Vector2.zero;

        while (timer < borderSlideDuration)
        {
            timer += Time.deltaTime;
            float t = timer / borderSlideDuration;

            //smoother
            t = Mathf.SmoothStep(0f, 1f, t);

            topBorder.anchoredPosition = Vector2.Lerp(topStart, toppEnd, t);
            bottomBorder.anchoredPosition = Vector2.Lerp(bottomStart, bottomEnd, t);

            yield return null;
        }

        //fix the wonky bit

        // make sure its aligned

        topBorder.anchoredPosition = toppEnd;
        bottomBorder.anchoredPosition = bottomEnd;


        //make the THe END part start as soon as bordeer reaaches 50 height

        if (theEndSequenceObject != null)
        {
            theEndSequenceObject.SetActive(true);
            Debug.Log("Borders DONE, PLAY THE END");

            Time.timeScale = 0f;
              
        }
    }


}



//the end is playing, but behind everything / weirdly placed in scene view
//make it follow the follow camera's view?
//stick to the other 1/3 of the screen