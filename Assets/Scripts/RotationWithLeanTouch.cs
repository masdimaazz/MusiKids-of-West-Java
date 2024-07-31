using UnityEngine;
using Lean.Touch;

public class RotateWithLeanTouch : MonoBehaviour
{
    // The camera the translation will be done relative to (none = world space)
    public Camera Camera;

    // Rotation speed
    public float RotationSpeed = 10.0f;

    protected virtual void Update()
    {
        // Get the fingers we want to use
        var fingers = LeanTouch.GetFingers(true, false);

        // Calculate the rotation values based on these fingers
        var twistDegrees = LeanGesture.GetTwistDegrees(fingers) * RotationSpeed;

        // Perform the rotation
        transform.Rotate(Vector3.up, -twistDegrees, Space.Self);
    }
}
