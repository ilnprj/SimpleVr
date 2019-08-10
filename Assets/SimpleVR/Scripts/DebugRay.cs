using UnityEngine;

public class DebugRay : MonoBehaviour
{
#if UNITY_EDITOR
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 5;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
#endif
}
