using UnityEngine;


public class StopPlayerLanding : MonoBehaviour
{
    private bool hasLanded = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasLanded == false)
        {
            if (collision.gameObject.CompareTag("FallFloor"))
            {
                hasLanded = true;

                Rigidbody rb = GetComponent<Rigidbody>();

                if(rb != null)
                {
                    rb.linearVelocity = Vector3.zero;

                    //remove the bounce when boy lands
                    rb.angularVelocity = Vector3.zero;
                    rb.isKinematic = true;
                }

                Debug.Log("Player landed and STOPPEd");

            }
        }
    }
}
