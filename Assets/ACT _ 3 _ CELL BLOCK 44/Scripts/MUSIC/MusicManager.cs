using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip gameplayMusic;
    [SerializeField] private AudioClip exitMusic;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        musicSource.clip = gameplayMusic;
        musicSource.Play();
    }

    public void PlayExitMusic()
    {
        musicSource.Stop();
        musicSource.clip = exitMusic;
        musicSource.Play();
    }

}
