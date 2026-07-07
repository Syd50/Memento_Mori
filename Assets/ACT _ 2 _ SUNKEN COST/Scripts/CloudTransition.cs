using System.Collections;
using UnityEngine;


public class CloudTransition : MonoBehaviour
{

    //cloud is UI image, uses RectTransform - anchoredPostion

    //public float speed = 5f;

    public float speed = 500f;
    public float startX = -1200f;
    public float endX = 1200f;
    public float yPosition = 200f;

    //after cloud leaves screen, wait and then new button and cloud pop up
    public GameObject yesButton;

    private RectTransform rect;


    private void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(startX, yPosition);
        //button should not be visible at start
        yesButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.right * speed *  Time.deltaTime);

        rect.anchoredPosition += Vector2.right * speed * Time.deltaTime;

        if(rect.anchoredPosition.x >= endX)
        {
            gameObject.SetActive(false); 
            //when we reach end pos, a coroutine should start to count down + reveal the next button
            StartCoroutine(ShowButton());
        }

    }

    IEnumerator ShowButton()
    { //coroutine cant start if the object is inactive 
        //how long it waits after cloud is gone


        yield return new WaitForSeconds(1f) ;

        gameObject.SetActive(false);
        //and thne button turns on (visible)
        yesButton.SetActive(true);

        //next switch camera from WIDE to CLOSE - another script
    }

    //this needs to be a separate scrip[t
}
