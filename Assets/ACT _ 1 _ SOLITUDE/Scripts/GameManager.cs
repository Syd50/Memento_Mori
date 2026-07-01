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
            grainCanvasGroup.alpha = 0f;
        }
        else
        {
            Debug.Log("Missing Canvas Group component on " + filmGrain.name);
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
    private bool hasExited = false;

    public void PlayerReachedExit()
    {
        Debug.Log("EXIT REACHED");

        if (hasExited) return;
        hasExited = true;

        StartCoroutine(ExitSequence());
    }


    //exit coroutine for ACT  3

    //change to fade in WHEN player lands
    private IEnumerator ExitSequence()
    {

        Debug.Log("EXIT SEQUENCE STARTED");

        //just wait for player to land instead??

        yield return new WaitForSeconds(exitDelay);

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
                grainCanvasGroup.alpha = Mathf.Lerp(0f, 0.7f, timer / fadeDuration);
                yield return null;
            }

            //finish at exactly 0.7
            grainCanvasGroup.alpha = 0.7f;
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


}
