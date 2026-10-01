using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour
{

    [Header("Stay Button")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonSound;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private float dialogueTime = 3f;

    public void ButtonOnePressed()
    {
        // Play sound
        if (audioSource != null && buttonSound != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }

        // Show dialogue
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true);
            StartCoroutine(HideDialogue());
        }
    }

    private IEnumerator HideDialogue()
    {
        yield return new WaitForSeconds(dialogueTime);

        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }
}
