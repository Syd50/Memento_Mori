//using UnityEngine;

//public class FallFloor : MonoBehaviour
//{
//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

//            if (playerRb != null)
//            {
//                //floor is like an obstacle that slows boy down
//                // falling at a really high speed?
//                //can i slow it down
//                //or just stop when hit floor? Freeze game?

//                playerRb.linearVelocity = Vector3.zero;
//                playerRb.angularVelocity = Vector3.zero;
//                playerRb.isKinematic = true;
//            }

//            ////need to stop the player as soon as hits floor
//            //GameManager.Instance.PlayerHitFloorAfterFall();
//        }
//    }
//}