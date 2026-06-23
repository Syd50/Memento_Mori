using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverPanel;

    private void Awake()
    {
        //store as a static variable called Instance
        //Singleton - makes sure class only has one instance in entire game, everyone has global access to it
        //ANALOGY - TV remote. There is only ONE, everyone uses the same one to contorl the TV. Don't want 5 remotes controlling same TV (singleton prevents this)
        //other scripts will be able to access using class name - instance
        Instance = this;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        //pause entire game by stopping unity's time system
        // 0 = paused
        // 1 = normal speed
        Time.timeScale = 0f;
    }

}
