using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private CinemachineCamera gamePlayCamera;
    [SerializeField] private CinemachineCamera followCamera;



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ragdoll"))
        {
            gamePlayCamera.Priority = 10;
            followCamera.Priority = 20;
        }
    }

}