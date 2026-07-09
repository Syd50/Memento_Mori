using UnityEngine;

public class PlayetExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            MusicManager.Instance.PlayExitMusic();
            GameManager.Instance.PlayerReachedExit();
        }
    }
}

// get fall time in the console to track it