using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera startCam;
    [SerializeField] private CinemachineCamera gamePlayCamera;
    [SerializeField] private CinemachineCamera followCamera;
    [SerializeField] private CinemachineCamera fallingCamera;

    //need camera to wait a little, so follow cam for  a bit and then falling camera
    [SerializeField] private float fallingCameraDelay = 6f;

    [SerializeField] private float startCameraTime = 2f;





    private IEnumerator Start()
    {
        startCam.Priority = 30;
        gamePlayCamera.Priority = 10;
        followCamera.Priority = 0;
        fallingCamera.Priority = 0;


        yield return new WaitForSeconds(startCameraTime);

        startCam.Priority = 0;
        gamePlayCamera.Priority = 20;
        followCamera.Priority = 10;
        fallingCamera.Priority = 0;
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Ragdoll"))
        {


            startCam.Priority = 0;
            gamePlayCamera.Priority = 10;
            followCamera.Priority = 20;
            fallingCamera.Priority = 0;
        }
    }





    //public void SwitchToFallingCamera()
    //{
    //    startCam.Priority = 0;
    //    gamePlayCamera.Priority = 0;
    //    followCamera.Priority = 0;
    //    fallingCamera.Priority = 30;
    //}






    public void StartFallingCameraSequence()
    {
        StartCoroutine(FallingCameraSequence());
    }

    private IEnumerator FallingCameraSequence()
    {
        // Keep the follow camera active first
        followCamera.Priority = 20;
        fallingCamera.Priority = 0;



        // Wait for 6 seconds
        yield return new WaitForSeconds(fallingCameraDelay);

        // Now switch to the falling camera
        followCamera.Priority = 0;
        fallingCamera.Priority = 30;
    }
}
//exit then follow camera the falling camera
//waiting - coroutine