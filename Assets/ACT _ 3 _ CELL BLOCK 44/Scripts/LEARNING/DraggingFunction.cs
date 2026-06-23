//using System.Collections;
//using UnityEngine;
//public class DraggingFunction : MonoBehaviour
//{
//    [SerializeField] private Rigidbody playerRb;
//    [SerializeField] private float forceMultiplier = 0.1f;

//    private Vector2 startTouchPos;
//    private Vector2 currentTouchPos;

//    private bool isDragging;

//    private void Start()
//    {
//        Debug.LogError("START TEST");
//    }

//    private void Update()
//    {

//        if (Input.touchCount == 0)

//            return;

//        if (Input.touchCount > 0)
//        {
//            Debug.Log("TOUCH DETECTED");
//        }
//        //if (!canSwipe)
//        //    return;

       


//        Touch touch = Input.GetTouch(0);

//        switch (touch.phase)
//        {
//            case TouchPhase.Began:

//                Debug.Log("BEGAN");

//                startTouchPos = touch.position;
//                isDragging = true;

//                break;

//            case TouchPhase.Moved:

//                Debug.Log("MOVED");


//                currentTouchPos = touch.position;

//                break;

//            case TouchPhase.Ended:

//                Debug.Log("ENDED");
                

//                if (isDragging)
//                {
//                    Vector2 dragVector =
//                        //currentTouchPos - startTouchPos;
//                        startTouchPos - currentTouchPos;

//                    Debug.LogError("Drag:" + dragVector);

//                    Vector3 forceVector = new Vector3(
//                        dragVector.x, dragVector.y, 0f).normalized;


//                    //this is doing nothing becaus it has no values
//                    playerRb.AddForce(
//                        forceVector * 5f, ForceMode.Impulse);

//                    StartCoroutine(SwipeCoolDown());

//                        //dragVector * forceMultiplier,
//                        //ForceMode2D.Impulse);
//                    //swipe.normalized * fixedForce,
//                    //ForceMode2D.Impulse); 
//                }

//                isDragging = false;

//                break;
//        }

//    }


//    private bool canSwipe = true;
//    private Vector3 forceVector;

//    IEnumerator SwipeCoolDown()
//    {
//        canSwipe = false;
//        yield return new WaitForSeconds(0.5f);

//        canSwipe = true;
//    }




//}












//{
//    //can the ball be dragged or not?
//    private bool _isDragActive = false;

//    private Vector2 _screenPosition;

//    private Vector3 _worldPosition;

//    //private Draggable _lastDragged;   -- do i really need this if its jst one object


//    private void Awake()
//    {
//        //before we start we need to make sure there is only one of these controllers in the scene
//        DraggingFunction[] controller = FindObjectsOfType<DraggingFunction>();
//        if(controller.Length > 1)
//        {
//            //destroy if there is more than one, because it will be a duplicate
//            Destroy(gameObject);
//        }
//    }

//    private void Update()
//    {
//        if(Input.touchCount > 0)
//        {
//            _screenPosition = Input.GetTouch(0).position;
//        }
//        else
//        {
//            return;
//        }

//        //otherwise, so if there is a touch, then we convert the screen touch position to a world coordinate

//        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

//        if (_isDragActive)
//        {
//            Drag();
//        }
//        else
//        {
//            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
//            if(hit.collider != null)
//            {
//                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
//                if(draggable != null)
//                {

//                }

//            }
//        }



//    }



//    void InitDrag()
//    {

//    }

//    void Drag()
//    {

//    }

//    void Drop()
//    {

//    }




//}

