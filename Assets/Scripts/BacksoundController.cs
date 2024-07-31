using UnityEngine;
using Vuforia;

public class BacksoundController : MonoBehaviour
{
    private AudioSource audioSource;
    private ObserverBehaviour observerBehaviour;

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Register event handlers
        observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnDestroy()
    {
        // Unregister event handlers
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            // Play the backsound when the target is detected
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Stop the backsound when the target is lost
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
