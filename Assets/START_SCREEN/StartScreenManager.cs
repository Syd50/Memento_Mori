using UnityEngine;
using System.Collections;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject introSequence;
    [SerializeField] private GameObject buttonOne;
    [SerializeField] private GameObject buttonTwo;

    [SerializeField] private float introAnimationTime = 5f;

    private IEnumerator Start()
    {
        if (buttonOne != null)
        {
            buttonOne.SetActive(false);
        }

        if (buttonTwo != null)
        {
            buttonTwo.SetActive(false);
        }

        if (introSequence != null)
        {
            introSequence.SetActive(true);
        }

        yield return new WaitForSeconds(introAnimationTime);

        if (buttonOne != null)
        {
            buttonOne.SetActive(true);
        }

        if (buttonTwo != null)
        {
            buttonTwo.SetActive(true);
        }
    }
}