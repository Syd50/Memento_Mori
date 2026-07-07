using Unity.Cinemachine;
using UnityEditor;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{

    //just switching priority

    public CinemachineCamera wideCam;
    public CinemachineCamera closeCam;

    public void SwitchToClose()
    {
        wideCam.Priority = 0;
        closeCam.Priority = 10;
    }

}
