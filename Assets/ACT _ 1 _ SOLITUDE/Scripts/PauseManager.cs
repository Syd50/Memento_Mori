//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class PauseManager : MonoBehaviour
//{
//    public static PauseManager Instance;

//    [Header("References")]
//    public GameObject pausePanel;
//    public AudioSource musicSource;

//    [Header("Settings")]
//    [Range(0f, 1f)] public float pausedMusicVolume = 0.3f;
//    private float normalMusicVolume;

//    private bool isPaused = false;

//    private void Awake()
//    {
//        Instance = this;
//    }

//    private void Start()
//    {
//        if (musicSource != null)
//            normalMusicVolume = musicSource.volume;

//        pausePanel.SetActive(false);
//    }

//    public void TogglePause()
//    {
//        if (isPaused) Resume();
//        else Pause();
//    }

//    public void Pause()
//    {
//        isPaused = true;
//        Time.timeScale = 0f; // freezes gameplay (movement, spawning, physics)
//        pausePanel.SetActive(true);

//        if (musicSource != null)
//            musicSource.volume = pausedMusicVolume;
//    }

//    public void Resume()
//    {
//        isPaused = false;
//        Time.timeScale = 1f;
//        pausePanel.SetActive(false);

//        if (musicSource != null)
//            musicSource.volume = normalMusicVolume;
//    }

//    public void Restart()
//    {
//        Time.timeScale = 1f; // reset before reloading, or the new scene loads frozen
//        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//    }

//    public void QuitGame()
//    {
//        Application.Quit();
//    }
//}