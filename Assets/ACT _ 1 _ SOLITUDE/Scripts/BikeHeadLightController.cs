using UnityEngine;

public class BikeHeadLightController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalFloat("_BikeX", transform.position.x);
        Shader.SetGlobalFloat("_BikeZ", transform .position.y);
    }
}
