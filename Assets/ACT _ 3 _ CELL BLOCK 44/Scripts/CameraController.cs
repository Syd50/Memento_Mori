using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera startCam;
    [SerializeField] private CinemachineCamera gamePlayCamera;
    [SerializeField] private CinemachineCamera followCamera;

    [SerializeField] private float startCameraTime = 2f;


    private IEnumerator Start()
    {
        startCam.Priority = 30;
        gamePlayCamera.Priority = 10;
        followCamera.Priority = 0;

        yield return new WaitForSeconds(startCameraTime);

        startCam.Priority = 0;
        gamePlayCamera.Priority = 20;
        followCamera.Priority = 10;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ragdoll"))
        {
            startCam.Priority = 0;
            gamePlayCamera.Priority = 10;
            followCamera.Priority = 20;
        }
    }

}