using UnityEngine;

public class PlayetExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            GameManager.Instance.PlayerReachedExit();
        }
    }
}
