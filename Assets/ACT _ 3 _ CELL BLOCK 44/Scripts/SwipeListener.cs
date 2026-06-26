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
        rb = GetComponent<Rigidbody>();

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
        Vector3 forceDirection = Vector3.zero;

        switch (direction)
        {
            case MobileInputManager.SwipeDirection.Right:
                forceDirection = Vector3.right;
                break;
                case MobileInputManager.SwipeDirection.Left:
                forceDirection = Vector3.left;
                break;
                case MobileInputManager.SwipeDirection.Up:    // check forward
                forceDirection = Vector3.up;
                break;
                case MobileInputManager.SwipeDirection.Down:   // check back
                forceDirection = Vector3.down; 
                break;
        }

        //forceDirection += Vector3.up * upwardForce;

        rb.AddForce(forceDirection * throwForce, ForceMode.Impulse);
        //ForceMode.VelocityChange  -- try later


    }

 
}
