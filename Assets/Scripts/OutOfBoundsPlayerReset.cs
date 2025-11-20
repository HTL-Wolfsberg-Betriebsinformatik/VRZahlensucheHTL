using System;
using UnityEngine;
using Unity.XR.CoreUtils;

public class OutOfBoundsPlayerReset : MonoBehaviour
{
    public XROrigin xrOrigin;
    public float minHight;

    public Vector3 tp;
    public Quaternion tr;

    private void Update()
    {
        if (xrOrigin.GetComponentInChildren<Camera>().transform.position.y < minHight)
        {
            TeleportPlayer(tp, tr);
        }
    }
    
    private void TeleportPlayer(Vector3 targetPosition, Quaternion targetRotation)
    {
        if (xrOrigin == null) return;

        MatchRigRotation(targetRotation);
        xrOrigin.MoveCameraToWorldLocation(targetPosition);
    }

    private void MatchRigRotation(Quaternion targetRotation)
    {
        Vector3 cameraForward = xrOrigin.Camera.transform.forward;
        Vector3 cameraForwardProjected = Vector3.ProjectOnPlane(cameraForward, Vector3.up).normalized;

        float angleDiff = Vector3.SignedAngle(cameraForwardProjected, targetRotation * Vector3.forward, Vector3.up);

        xrOrigin.transform.Rotate(0f, angleDiff, 0f);
    }
}
