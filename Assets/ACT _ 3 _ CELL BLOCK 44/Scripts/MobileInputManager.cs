using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class MobileInputManager : MonoBehaviour
{

    public static MobileInputManager instance;

    [SerializeField] private float swipeThreshold = 0.2f;

    private Vector3 startScreenPos = Vector3.zero;
    private Vector3 endScreenPos = Vector3.zero;

    public enum SwipeDirection

    {
        Right, Left, Up, Down
    }

    //---------------------------------------------------------------- delegate / event pairs ---------------------------------------------------------------------------------
    //name delegate with 'handler' to differentiate later between delegate and event.
    public delegate void OnSwipeHandler(SwipeDirection direction, Vector3 startScreenPosition, Vector3 endScreenPosition);
    public event OnSwipeHandler OnSwipe;

    private void Awake()
    {
        //'this' specific copy of this script
        instance = this;
    }
    void Start()
    {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
    }

    void Update()
    {
        CheckForTouchInput();
    }

    private void CheckForTouchInput()
    {
        //Are there any touched being deteced?
        if (Touch.activeTouches.Count > 0)
        {
            //If yes, check the phase of the first deteced touch
            if (Touch.activeTouches[0].began)
            {
                //If touch has started, record touch screen position
                startScreenPos = Touch.activeTouches[0].screenPosition;
            }
            else if (Touch.activeTouches[0].ended)
            {
                //if touch has ended, record touch screen position
                endScreenPos = Touch.activeTouches[0].screenPosition;
                //Check if the touch was a swipe
                CheckForSwipe();
            }
        }
    }

    private void CheckForSwipe()
    {
        //convert touch start pos into world coordinates
        startScreenPos.z = 1f;
        Vector3 startWorldPos = Camera.main.ScreenToWorldPoint(startScreenPos);

        //Convert touch end pos into worold coordinates
        endScreenPos.z = 1f;
        Vector3 endWorldPos = Camera.main.ScreenToWorldPoint(endScreenPos);

        //calculate distance between start and end world position
        float swipeDistance = Vector3.Distance(startWorldPos, endWorldPos);

        //waas the swipe distance long enough to count as a swipe;
        if (swipeDistance >= swipeThreshold)
        {
            //determine the larger input = compare the amount moved on  the vertical and horizontal axis
            //helps determine the dominant axis for swipe

            //record distance moved on each of those axis
            //maths abs - absolute - converts minus numbers into postiive ones, 
            float xDist = Mathf.Abs(startScreenPos.x - endScreenPos.x);
            float yDist = Mathf.Abs(startScreenPos.y - endScreenPos.y);

            if (xDist > yDist)
            {
                //dominant swipe dierction is horizontal

                if (startScreenPos.x < endScreenPos.x)
                {
                    ////Send out meesage that we have swiped right
                    Debug.Log("swiped right");
                    //on swipe - broadcasts message
                    //Invoke - sends it into game
                    //what direction swipe was in, its direction,  start and end pos
                    OnSwipe?.Invoke(SwipeDirection.Right, startScreenPos, endScreenPos);
                }
                else if (startScreenPos.x > endScreenPos.x)
                {
                    //sned out message we have swiped left
                    Debug.Log("Swiped Left");
                    OnSwipe?.Invoke(SwipeDirection.Left, startScreenPos, endScreenPos);
                }
            }
            else
            {
                //dominant swipe direction is vertical

                if (startScreenPos.y < endScreenPos.y)
                {
                    ////Send out meesage that we have swiped up
                    Debug.Log("Swiped Up");
                    OnSwipe?.Invoke(SwipeDirection.Up, startScreenPos, endScreenPos);
                }
                else if (startScreenPos.y > endScreenPos.y)
                {
                    ////Send out meesage that we have swiped up
                    Debug.Log("Swiped down");
                    OnSwipe?.Invoke(SwipeDirection.Down, startScreenPos, endScreenPos);
                }
            }
        }
    }
}
