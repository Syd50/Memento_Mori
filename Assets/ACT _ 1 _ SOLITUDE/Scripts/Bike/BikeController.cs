using UnityEngine;
using UnityEngine.InputSystem;

public class BikeController : MonoBehaviour
{
    //movement settings
    public float tiltSensitivity = 30f;
    public float roadWidthLimit = 2f;

    //smoothing out visuals
    public float leanAmount = 25f;
    //how quickly bike rotate towards its target lean angle
    public float smoothLeanSpeed = 5f;

    private void Start()
    {
        //new input system - wake up accelerometer
        //check if the device has an accelerometer
        if(Accelerometer.current != null)
        {
            //turns on accelerometer
            InputSystem.EnableDevice(Accelerometer.current);
            //how often accelerometer updates
            Accelerometer.current.samplingFrequency = 60f;
        }
    }


    private void Update()
    {
        //create a var to store tilt amount
        //start at 0 every frame
        float tiltInput = 0f;

        //read accelerometer data 
        //check accelerometer exists, accelerometer enabled - both must be true
        if (Accelerometer.current != null && Accelerometer.current.enabled)
        {
            //read current acceleration value
            tiltInput = Accelerometer.current.acceleration.ReadValue().x;
        }

        //move bike side to side
        float newXPosition = transform.position.x +(tiltInput * tiltSensitivity * Time.deltaTime);
        //keeps bike on the road, restrict value between a min and max
        newXPosition = Mathf.Clamp(newXPosition, -roadWidthLimit, roadWidthLimit);

        //only y and z
        //update bike position
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

        //smooth out the tilting 
        float targetZRotation = -tiltInput * leanAmount;

        Quaternion targetRotation = Quaternion.Euler(0, 0, targetZRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smoothLeanSpeed);

    }
}