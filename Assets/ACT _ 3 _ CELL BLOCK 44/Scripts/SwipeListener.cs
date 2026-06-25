using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class SwipeListener : MonoBehaviour
{
    [SerializeField] private Color rightColour;
    [SerializeField] private Color leftColour;
    [SerializeField] private Color upColour;
    [SerializeField] private Color downColour;

    private MeshRenderer myRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();

        MobileInputManager.instance.OnSwipe += OnSwipeReceived;

    }

    private void OnDistable()
    {
        //always make sure when you have a listener, that you also always remove that listner
        MobileInputManager.instance.OnSwipe -= OnSwipeReceived;
    }

    private void OnSwipeReceived(MobileInputManager.SwipeDirection direction, Vector3 startScreenPosition, Vector3 endScreenPosition)
    {
        switch (direction)
        {
            case MobileInputManager.SwipeDirection.Right:
                myRenderer.material.color = rightColour;
                break;
                case MobileInputManager.SwipeDirection.Left:
                myRenderer.material.color = leftColour;
                break;
                case MobileInputManager.SwipeDirection.Up:  
                myRenderer.material.color = upColour;
                break;
                case MobileInputManager.SwipeDirection.Down:
                myRenderer.material.color = downColour;
                break;
        }
    }

 
}
