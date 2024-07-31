using UnityEngine;
using UnityEngine.UI;

public class PlayMusicButton : MonoBehaviour
{
    public Button playButton; // Drag your button here in the inspector
    public AudioSource audioSource; // Drag your AudioSource component here in the inspector

    void Start()
    {
        // Make sure the audio is not playing initially
        audioSource.playOnAwake = false;
        audioSource.Stop();

        // Add a listener to the button to call the PlayMusic function when clicked
        playButton.onClick.AddListener(PlayMusic);
    }

    void PlayMusic()
    {
        // Check if the audio is already playing
        if (!audioSource.isPlaying)
        {
            // Play the audio
            audioSource.Play();
        }
    }
}
