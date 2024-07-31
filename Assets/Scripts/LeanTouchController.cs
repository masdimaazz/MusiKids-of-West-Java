using UnityEngine;
using Lean.Touch;
using System.Collections.Generic;

public class LeanTouchController : MonoBehaviour
{
    public float scaleSpeed = 0.1f;
    public float rotationSpeed = 0.5f;
    public float moveSpeed = 0.05f;
    public float smoothFactor = 0.1f;

    private Vector3 targetScale;
    private Quaternion targetRotation;
    private Vector3 targetPosition;

    private void Start()
    {
        targetScale = transform.localScale;
        targetRotation = transform.rotation;
        targetPosition = transform.position;
    }

    private void OnEnable()
    {
        // Subscribe to Lean Touch events
        LeanTouch.OnGesture += HandleGesture;
    }

    private void OnDisable()
    {
        // Unsubscribe from Lean Touch events
        LeanTouch.OnGesture -= HandleGesture;
    }

    private void Update()
    {
        // Smoothly interpolate towards the target values
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, smoothFactor);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothFactor);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothFactor);
    }

    private void HandleGesture(List<LeanFinger> fingers)
    {
        if (LeanGesture.GetPinchScale(fingers) != 1.0f)
        {
            // Scale the object smoothly
            float pinchScale = LeanGesture.GetPinchScale(fingers);
            targetScale *= pinchScale;
        }

        if (LeanGesture.GetTwistDegrees(fingers) != 0.0f)
        {
            // Rotate the object smoothly
            float twistDegrees = LeanGesture.GetTwistDegrees(fingers);
            targetRotation *= Quaternion.Euler(0, 0, twistDegrees * rotationSpeed);
        }

        if (LeanGesture.GetScreenDelta(fingers) != Vector2.zero)
        {
            // Move the object smoothly
            Vector2 screenDelta = LeanGesture.GetScreenDelta(fingers);
            Vector3 worldDelta = Camera.main.ScreenToWorldPoint(new Vector3(screenDelta.x, screenDelta.y, Camera.main.WorldToScreenPoint(transform.position).z));
            targetPosition += new Vector3(worldDelta.x, 0, worldDelta.y) * moveSpeed;
        }
    }
}
