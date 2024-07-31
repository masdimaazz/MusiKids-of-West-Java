using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceAndAngleMeasurement : MonoBehaviour
{
    public GameObject imageTarget; // Assign your ImageTarget GameObject in the inspector
    public TextMeshProUGUI distanceText; // Assign the TextMeshProUGUI for distance in the inspector
    public TextMeshProUGUI angleText; // Assign the TextMeshProUGUI for angle in the inspector

    private bool isMarkerVisible = false;

    void Update()
    {
        // Check if the marker is visible
        if (imageTarget.activeInHierarchy)
        {
            isMarkerVisible = true;

            // Get the position and rotation of the image target
            Vector3 targetPosition = imageTarget.transform.position;
            Quaternion targetRotation = imageTarget.transform.rotation;

            // Calculate the distance from the camera to the image target
            float distance = Vector3.Distance(Camera.main.transform.position, targetPosition);

            // Calculate the angle between the camera forward vector and the image target forward vector
            float angle = Quaternion.Angle(Camera.main.transform.rotation, targetRotation);

            // Convert distance from meters to centimeters
            distance *= 100;

            // Display the distance and angle in the UI
            distanceText.text = "Distance to marker: " + distance.ToString("F2") + " cm";
            angleText.text = "Angle to marker: " + angle.ToString("F2") + " degrees";
        }
        else if (isMarkerVisible)
        {
            isMarkerVisible = false;

            // Clear the UI when the marker is not visible
            distanceText.text = "Distance to marker: -- cm";
            angleText.text = "Angle to marker: -- degrees";
        }
    }
}
