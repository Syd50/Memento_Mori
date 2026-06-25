//using UnityEngine;

//public class TouchInput : MonoBehaviour
//{
//    [SerializeField] private float moveAmount = 1f;

//    private Vector2 startTouchPos;
//    private float distance;


//    // Update is called once per frame
//    private void Update()
//    {
//        if(Input.touchCount == 0)
//            return;

//        Touch touch = Input.GetTouch(0);

//        switch (touch.phase)
//        {
//            case TouchPhase.Began:

//                startTouchPos = touch.position;

//                break;

//            case TouchPhase.Ended:

//                Vector2 swipe = touch.position - startTouchPos;

//                //TAP

//                if(distance < 50f)
//                {
//                    transform.position += Vector3.forward * moveAmount;
//                    return;
//                }

//                //SWIPe
//                if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
//                {
//                    //horizontal swipe

//                    if (swipe.x > 0)
//                    {
//                        transform.position += Vector3.right * moveAmount;
//                    }
//                    else
//                    {
//                        transform.position += Vector3.left * moveAmount;
//                    }
//                }
//                else
//                {
//                    //verticle swipe

//                    if (swipe.y > 0)
//                    {
//                        transform.position += Vector3.up * moveAmount;
//                    }
//                    else
//                    {
//                        transform.position += Vector3.down * moveAmount;
//                    }
//                }
//                break;
//        }
//    }
//}
