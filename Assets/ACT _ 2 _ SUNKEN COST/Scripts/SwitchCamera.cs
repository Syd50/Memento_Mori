using UnityEngine;
using Unity.Cinemachine;

public class SwitchCamera : MonoBehaviour
{
    public CinemachineCamera wideCam;
    public CinemachineCamera closeCam;
    public CinemachineCamera fallingCam;
    public CinemachineCamera quoteOneCam;

    void Start()
    {
        wideCam.Priority = 100;
        closeCam.Priority = 0;
        fallingCam.Priority = 0;
        quoteOneCam.Priority = 0;
    }

    public void SwitchToClose()
    {
        Debug.Log("Switching ");

        wideCam.Priority = 0;
        closeCam.Priority = 100;
        fallingCam.Priority = 0;
        quoteOneCam.Priority = 0;

    }

    public void SwitchingToFalling()
    {
        Debug.Log("Switching to falling camera");

        wideCam.Priority = 0;
        closeCam.Priority = 0;
        fallingCam.Priority = 100;
        quoteOneCam.Priority = 0;
    }

    public void SwitchToQuoteOne()
    {
        wideCam.Priority = 0;
        closeCam.Priority = 0;
        fallingCam.Priority = 0;
        quoteOneCam.Priority = 100;
    }
}