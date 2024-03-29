﻿using UnityEngine;

public class VrController : MonoBehaviour
{
    private Gyroscope gyroscope;
    private Quaternion rotation;
    private Quaternion multiplyRot;

    private bool gyroWork = default;
    private float calibrationYAngle;

    private void Start()
    {
        ActivateGyro();
    }

    private void ActivateGyro()
    {
        if (SystemInfo.supportsGyroscope && !gyroWork)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
            Application.targetFrameRate = 60;
            gyroWork = true;
        }
        else
        {
            Debug.LogError("Gyro is not supported this system");
        }
    }

    private void FixedUpdate()
    {
        if (gyroWork)
        {
            UpdateRotation();
        }
    }

    private void UpdateRotation()
    {
        transform.localRotation = gyroscope.attitude;
        transform.Rotate(0f, 0f, 180f, Space.Self);
    }
}
