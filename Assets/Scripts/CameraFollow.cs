using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;        // The target to follow (e.g. player)
    [SerializeField] private Vector3 offset;          // The offset from the target position
    [SerializeField] private float smoothTime = 0.3f; // Smooth time for camera transition

    private Vector3 currentVelocity = Vector3.zero;  // Used by SmoothDamp to smooth the transition

    private void Awake()
    {
       
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            
            Vector3 targetPosition = target.position + offset;

            
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
        }
    }
}
