using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    public AudioClip clickSound; // Drag and drop the click sound AudioClip here in the Inspector
    private AudioSource audioSource;
    public Button[] buttons; // Drag and drop the Buttons here in the Inspector

    private void Start()
    {
        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the AudioClip
        audioSource.clip = clickSound;

        // Add the click event to each button
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(PlayClickSound);
        }
    }

    private void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
