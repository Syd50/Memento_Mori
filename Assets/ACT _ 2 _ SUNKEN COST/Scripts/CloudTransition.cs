using UnityEngine;


public class CloudTransition : MonoBehaviour
{

    //cloud is UI image, uses RectTransform - anchoredPostion

    //public float speed = 5f;

    public float speed = 500f;
    public float startX = -1200f;
    public float endX = 1200f;
    public float yPosition = 200f;

    private RectTransform rect;


    private void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(startX, yPosition);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.right * speed *  Time.deltaTime);

        rect.anchoredPosition += Vector2.right * speed * Time.deltaTime;

        if(rect.anchoredPosition.x >= endX)
        {
            gameObject.SetActive(false);
        }

    }
}
