
using UnityEngine;


public class MonsterCollision : MonoBehaviour
{
    //using unity method - acts like a motion sensor
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("STAYING WITH: " + other.name);

        //the thing we hit must have a tag - 'player'
        if (other.CompareTag("Player"))
        {
            //Debug.Log("PLayer hit monster");

            GameManager.Instance.GameOver();
        }

    }


}
