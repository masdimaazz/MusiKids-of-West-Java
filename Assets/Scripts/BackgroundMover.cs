using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public float speed = 0.1f; // Kecepatan pergerakan background
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Menggerakkan background secara horizontal
        float newPosition = Mathf.Repeat(Time.time * speed, 1);
        transform.position = startPosition + Vector3.right * newPosition;
    }
}
