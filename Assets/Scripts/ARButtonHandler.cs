using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Collections.Generic;

public class ARButtonHandler : MonoBehaviour
{
    public List<GameObject> buttons; // Drag and drop the button GameObjects here in the Inspector

    private void Start()
    {
        // Initially hide all buttons
        foreach (var button in buttons)
        {
            button.SetActive(false);
        }

        // Register event handlers
        var observer = GetComponent<ObserverBehaviour>();
        if (observer)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnDestroy()
    {
        // Unregister event handlers
        var observer = GetComponent<ObserverBehaviour>();
        if (observer)
        {
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED ||
            status.Status == Status.LIMITED)
        {
            // Show all buttons when the target is detected
            foreach (var button in buttons)
            {
                button.SetActive(true);
            }
        }
        else
        {
            // Hide all buttons when the target is lost
            foreach (var button in buttons)
            {
                button.SetActive(false);
            }
        }
    }
}
