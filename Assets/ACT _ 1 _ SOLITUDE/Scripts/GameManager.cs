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

    public float fadeDuration = 1.5f;
    //need to freeze player movement after collision with monster
    //public BikeController bikeController;   ----------------------------------- Bike isnt moving, ROAD IS

    //ACT 3
    [SerializeField] private float exitDelay = 2f;

    //[SerializeField] private GameObject creditSequence;


    //ACT 1
    private void Awake()
    {
        //store as a static variable called Instance
        //Singleton - makes sure class only has one instance in entire game, everyone has global access to it
        //ANALOGY - TV remote. There is only ONE, everyone uses the same one to contorl the TV. Don't want 5 remotes controlling same TV (singleton prevents this)
        //other scripts will be able to access using class name - instance
        Instance = this;
    }

    //private bool gameStarted = false;

    //private void Start()
    //{
    //    //show start screen
    //    startPanel.SetActive(true);

    //    //hide over actual game
    //    gameOverPanel.SetActive(false);

    //    //pause game
    //    Time.timeScale = 0f;
    //}

    //touch anywhere for now and the game starts
    //private void Update()
    //{
    //    if(!gameStarted&& Input.touchCount > 0)
    //    {
    //        StartGame();
    //    }
    //}

    //public void StartGame()
    //{
    //    startPanel.SetActive(false);
    //    Time.timeScale = 1f;
    //}

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

    private IEnumerator ExitSequence()
    {

        Debug.Log("EXIT SEQUENCE STARTED");
        yield return new WaitForSeconds(exitDelay);

        float timer = 0f;
        Color colour = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            colour.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = colour;
            yield return null;
        }

        //ending panel, change to png sequence later

        //creditSequence.SetActive(true);
        //pause on black screen for now
        Time.timeScale = 0f;

    }


}
