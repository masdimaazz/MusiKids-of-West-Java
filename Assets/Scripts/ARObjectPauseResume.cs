using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class ARObjectPauseResume : MonoBehaviour
{
    public GameObject arObject; // Drag and drop the AR object here in the Inspector
    public Button pauseButton; // Drag and drop the Pause Button here in the Inspector
    public Button resumeButton; // Drag and drop the Resume Button here in the Inspector

    private bool isPaused = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Rigidbody arObjectRigidbody;
    private Animator arObjectAnimator;

    private void Start()
    {
        // Store the original position and rotation of the AR object
        originalPosition = arObject.transform.localPosition;
        originalRotation = arObject.transform.localRotation;

        // Get the Rigidbody and Animator components if they exist
        arObjectRigidbody = arObject.GetComponent<Rigidbody>();
        arObjectAnimator = arObject.GetComponent<Animator>();

        // Register button click events
        pauseButton.onClick.AddListener(PauseARObject);
        resumeButton.onClick.AddListener(ResumeARObject);

        // Initially hide the resume button
        resumeButton.gameObject.SetActive(false);
    }

    private void PauseARObject()
    {
        // Pause the AR object's Rigidbody if it exists
        if (arObjectRigidbody != null)
        {
            arObjectRigidbody.isKinematic = true;
        }

        // Pause the AR object's Animator if it exists
        if (arObjectAnimator != null)
        {
            arObjectAnimator.enabled = false;
        }

        isPaused = true;

        // Toggle button visibility
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
    }

    private void ResumeARObject()
    {
        // Resume the AR object's Rigidbody if it exists
        if (arObjectRigidbody != null)
        {
            arObjectRigidbody.isKinematic = false;
        }

        // Resume the AR object's Animator if it exists
        if (arObjectAnimator != null)
        {
            arObjectAnimator.enabled = true;
        }

        isPaused = false;

        // Toggle button visibility
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }
}
