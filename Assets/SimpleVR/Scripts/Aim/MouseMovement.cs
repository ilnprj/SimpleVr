using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField]
    private float sensivity = 100.0f;

    [SerializeField]
    private float clampAngle = 80.0f;
    private float rotY = default;
    private float rotX = default;
    private Quaternion resultRotation = default;
    
    private void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    private void FixedUpdate()
    {
        rotY += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        rotX += -Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        resultRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = resultRotation;
    }
}
