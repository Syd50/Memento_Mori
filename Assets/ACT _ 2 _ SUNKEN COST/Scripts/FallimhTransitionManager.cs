//using System.Collections;
//using UnityEngine;

//public class FallingTransitionManager : MonoBehaviour
//{
//    public GameObject inbetweenFishingSequence;
//    public GameObject fallingSequence;

//    public Transform cloudsGroup;
//    public Transform cloudsEndPoint;

//    public float cloudMoveDuration = 2f;
//    public float waitBeforeCameraSwitch = 3f;

//    public SwitchCamera switchCamera;

//    public void StartFallingTransition()
//    {
//        Debug.Log("START FALLING TRANSITION CALLED");
//        StartCoroutine(FallingTransition());
//    }

//    IEnumerator FallingTransition()
//    {
//        inbetweenFishingSequence.SetActive(false);
//        //fallingSequence.SetActive(true) ;


//        StartCoroutine(MoveClouds());

//        yield return new WaitForSeconds(waitBeforeCameraSwitch);

//        switchCamera.SwitchingToFalling();
//    }

//    IEnumerator MoveClouds()
//    {
//        Vector3 startPos = cloudsGroup.position;
//        Vector3 endPos = cloudsEndPoint.position;

//        float t = 0f;

//        while (t < cloudMoveDuration)
//        {
//            t +=  Time.deltaTime;
//            float progress =  t / cloudMoveDuration;

//            cloudsGroup.position = Vector3.Lerp(startPos, endPos, progress);

//            yield return null ;
//        }

//        cloudsGroup.position = endPos;
//    }
//}