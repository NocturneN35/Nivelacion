using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;        // The target to follow (e.g. player)
    [SerializeField] private Vector3 offset;          // The offset from the target position
    [SerializeField] private float smoothTime = 0.3f; // Smooth time for camera transition

    private Vector3 currentVelocity = Vector3.zero;  // Used by SmoothDamp to smooth the transition

    private void Awake()
    {
        // Initialize the offset to maintain the initial position difference between the camera and the target
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the target position using the offset
            Vector3 targetPosition = target.position + offset;

            // Smoothly move the camera to the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
        }
    }
}
