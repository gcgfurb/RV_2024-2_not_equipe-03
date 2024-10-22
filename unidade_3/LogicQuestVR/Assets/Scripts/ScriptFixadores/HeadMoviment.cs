using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMoviment : MonoBehaviour
{
    public Transform cameraTransform;
    public float minXRotation = -12.0f;
    public float maxXRotation = 12.0f;

    public float rotationSpeed = 2.0f;
    public float smoothTime = 0.5f;
    public float rotationThreshold = 1.0f;

    private float velocity;
    private float lastTargetYRotation;
    void Update()
    {
        if (cameraTransform != null)
        {
            float targetYRotation = cameraTransform.eulerAngles.y;

            float rotationDifference = Mathf.Abs(targetYRotation - lastTargetYRotation);

            if (rotationDifference > rotationThreshold)
            {
                float currentYRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetYRotation, ref velocity, smoothTime);
                transform.rotation = Quaternion.Euler(0, currentYRotation, 0);
                lastTargetYRotation = targetYRotation;
            }
        }

        if (cameraTransform != null)
        {
            float targetXRotation = cameraTransform.eulerAngles.x;
            if (targetXRotation > 180) targetXRotation -= 360;
            float clampedXRotation = Mathf.Clamp(targetXRotation, minXRotation, maxXRotation);
            transform.rotation = Quaternion.Euler(clampedXRotation, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
