using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    
    [Header("Zoom settings")]
    [Range(1f, 10f)]
    public float zoomSpeed = 4f;

    [Range(1f, 20f)]
    public float minZoom = 5f;

    [Range(10f, 30f)]
    public float maxZoom = 15f;
    
    private float currentZoom = 10f;

    [Header("Yaw settings")]
    
    [Range(10f, 300f)]
    public float yawSpeed = 100f;

    [Range(1f, 40f)]
    public float yawResetSpeed = 10f;
    
    [Range(1f, 10f)]
    public float yawTreshold = 1f;

    private float currentYaw = 0f;
    private bool resetYaw = false;

    [Space(10)]
    [Range(-10f, 10f)]
    public float pitch;

    void LateUpdate()
    {
        SetZoom();
        SetPich();
        SetYaw();
    }

    void SetZoom()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        transform.position = target.position + offset * currentZoom;
    }

    void SetPich() {
        transform.LookAt(target.position + Vector3.up * pitch);
    }

    void SetYaw()
    {
        if (Input.GetKeyDown("space"))
            resetYaw = true;

        if (resetYaw)
        {
            float currentYawAbs = Mathf.Abs(currentYaw);

            if (currentYawAbs <= yawTreshold || currentYawAbs >= (360 - yawTreshold))
            {
                currentYaw = 0f;
                resetYaw = false;
            }
            else
            {
                currentYaw = Mathf.LerpAngle(currentYaw, 0f, yawResetSpeed * Time.deltaTime);
            }
        }
        else
        {
            currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        }

        currentYaw = currentYaw % 360f; // Avoid to create very big numbers
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
