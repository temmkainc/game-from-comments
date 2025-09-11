using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Target to follow")]
    public Transform target;

    [Header("Camera settings")]
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    [Header("Optional limits")]
    public bool useLimits = false;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        if (useLimits)
        {
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);
        }

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        smoothedPosition.z = transform.position.z;

        transform.position = smoothedPosition;
    }
}
