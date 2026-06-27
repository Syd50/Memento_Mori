using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class SwipeListener : MonoBehaviour
{
    //affecting capsule's rigid body 
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float throwForce = 10f;
    //[SerializeField] private float upwardForce = 2f;


    //[SerializeField] private Color rightColour;
    //[SerializeField] private Color leftColour;
    //[SerializeField] private Color upColour;
    //[SerializeField] private Color downColour;


    // The swiping should 'hit' the character
    // AddForce
    //some force change when swipe


    //private MeshRenderer myRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //myRenderer = GetComponent<MeshRenderer>();

        //get rid of this, it overwrites when i put pelvis rb into rb slot. 
        //rb = GetComponent<Rigidbody>();

        MobileInputManager.instance.OnSwipe += OnSwipeReceived;

    }

    private void OnDistable()
    {
        //always make sure when you have a listener, that you also always remove that listner
        MobileInputManager.instance.OnSwipe -= OnSwipeReceived;
    }

    //the swipe directions dont change, just the colours do
    private void OnSwipeReceived(MobileInputManager.SwipeDirection direction, Vector3 startScreenPosition, Vector3 endScreenPosition)
    {

        //THIS LINE made up = forward and down = back
        //keep it --------------------------------------------------- tomorrow ------------------ > add some sort of vector.up * by some small ish value, so it lifts a bit
        Vector2 swipe = (endScreenPosition - startScreenPosition).normalized;
        //need to convert that to 3D force

        Vector3 forceDirection = new Vector3(swipe.x, 0f, swipe.y);

        forceDirection += Vector3.up * 0.8f;


        //switch (direction)
        //{
        //    case MobileInputManager.SwipeDirection.Right:
        //        forceDirection = Vector3.right;
        //        break;
        //        case MobileInputManager.SwipeDirection.Left:
        //        forceDirection = Vector3.left;
        //        break;
        //        case MobileInputManager.SwipeDirection.Up:    // FORWARD
        //        forceDirection = Vector3.up;
        //        break;
        //        case MobileInputManager.SwipeDirection.Down:   // BACK
        //        forceDirection = Vector3.down; 
        //        break;
        //}

        //forceDirection += Vector3.up * upwardForce;

        rb.AddForce(forceDirection * throwForce, ForceMode.Impulse);

        //ForceMode.VelocityChange  -- try later


    }

 
}
