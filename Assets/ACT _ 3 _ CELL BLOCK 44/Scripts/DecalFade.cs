using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal; //URP renderer

public class DecalFade : MonoBehaviour


{
    [SerializeField] private Transform decal;




    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "FallFloor")
        {
            decal.position = transform.position;
            decal.gameObject.SetActive(true);
        }
    }


}


































//{

//    //public float fadeDuration = 0.3f;

//    private DecalProjector projector;
//    //need to store the material on the decal -------------- need to change stuff in this
//    private Material materialInstance;

//    private float alpha = 0f;


//    //wont start fade until trigger
//    private bool fading = false;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {//beign immediately
//        //TriggerFade();
//        projector = GetComponent<DecalProjector>();
//        //get the material being used still neede to change stuff for this
//        materialInstance = projector.material;
//        //NEEDS OT BE FULLY TRANSPARENT
//        SetOpacity(0f);
//    }

//    //public void TriggerFade()
//    //{
//    //    //START INCREASING THE ALPHA AS THE TRIGGER IS SET OFF
//    //    fading = true;
//    //}

//    // Update is called once per frame
//    void Update()
//    {
//        //its false, stop running straigh away
//        //if (!fading) return;

//        //divide by duration 
//        //should be how long is it regardless of frame rates
//        //alpha += Time.deltaTime / fadeDuration;

//        ////keeos between 0 and 1
//        //alpha = Mathf.Clamp01(alpha);


//        ////reaches 1 - stop fading
//        //if (alpha >= 1f)
//        //    fading = false;
//    }

//    //better way to write materialInstance.SetFloat(...
//    //put everything in this function
//    void SetOpacity(float value)
//    {
//        //sets property called 'opacity'
//        //between 0 adn 1
//        materialInstance.SetFloat("_Opacity", value);
//    }

//}

////need to reference back to this where player is controlled