using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LeaveButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup greyPage;
    [SerializeField] private GameObject buttonsGroup;

    [SerializeField] private float waitTime = 5f;

    public void ShowGreyPage()
    {
        if (buttonsGroup != null)
        {
            buttonsGroup.SetActive(false);
        }

        if (greyPage != null)
        {
            greyPage.gameObject.SetActive(true);
            greyPage.alpha = 1f;
        }

        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene("ACT 1 - TEST");
    }
}
