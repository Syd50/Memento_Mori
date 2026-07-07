using UnityEngine;
using Unity.Cinemachine;

public class SwitchCamera : MonoBehaviour
{
    public CinemachineCamera wideCam;
    public CinemachineCamera closeCam;

    void Start()
    {
        wideCam.Priority = 100;
        closeCam.Priority = 0;
    }

    public void SwitchToClose()
    {
        Debug.Log("Switching ");

        wideCam.Priority = 0;
        closeCam.Priority = 100;

       
    }
}