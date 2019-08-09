using UnityEngine;

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

    /// <summary>
    /// Calibrates Y angle 
    /// </summary>
    public void Calibrate()
    {
        //FIXME: Calibrate it doesn't work now
        calibrationYAngle = transform.localEulerAngles.z;
        transform.Rotate(0f,-calibrationYAngle,180f,Space.Self);
        ActivateGyro();
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
