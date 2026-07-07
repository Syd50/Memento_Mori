using Unity.VisualScripting;
using UnityEngine;

public class WallImpact : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    //[SerializeField] private AudioClip wallHitSound;
    [SerializeField] private AudioClip[] wallHitSounds;
    [SerializeField] private float minImpactSpeed = 1.5f;

   private void OnCollisionEnter(Collision collision)
    {
        //no sounds when hits floor
        if (collision.gameObject.CompareTag("Floor"))
            return;

        //ignore small swipes, it doesnt look right
        if (collision.relativeVelocity.magnitude < minImpactSpeed)
            return;


        //play on walls on ceiling
        if (collision.gameObject.CompareTag("Wall"))
        {
            //audioSource.PlayOneShot(wallHitSound);
            int randomIndex = Random.Range(0, wallHitSounds.Length);
            audioSource.PlayOneShot(wallHitSounds[randomIndex]);
        }
        //else if (collision.gameObject.CompareTag("Ceiling"))
        //{
        //    audioSource.PlayOneShot(wallHitSound);
        //}
    }
}
// 