

//using UnityEngine;

//public class GravityController : MonoBehaviour
//{

//    [Header("Tilt Controls")]
//    public float tiltSensitivity = 15f;

//    [Header("Shaking interruptions")]
//    public float shakeFrequency = 2f;
//    public float shakeIntensity = 10f;

//    private Vector3 baseGravity;
//    private float timer;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        //default downwards gravity
//        baseGravity = new Vector3(0, -9.81f, 0);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //player's physical phone tilt - accelerometer
//        // horizontal mode
//        //x - left and right
//        //y - forwards and back
//        float tiltX = Input.acceleration.x * tiltSensitivity;
//        float tiltY = Input.acceleration.y * tiltSensitivity;

//        //chaos TEST - throw player off a little
//        timer += Time.deltaTime * shakeFrequency;
//        float chaosX = Mathf.Sin(timer) * shakeIntensity;
//        float chaosY = Mathf.Cos(timer * 1.5f) * (shakeIntensity * 0.5f);

//        //combine tilt and chaotic movements
//        Vector3 dynamicGravity = new Vector3(tiltX + chaosX, baseGravity.y + chaosY, 0f);

//        //override unity's physics immediately
//        Physics.gravity = dynamicGravity;
//    }
//}
