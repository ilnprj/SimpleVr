using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField]
    private float maxDistanceRay = 10f;
    private RaycastHit raycast;
    private Vector3 dir = default;
    private void FixedUpdate()
    {
        dir = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, dir, out raycast, maxDistanceRay))
        {
            Debug.DrawRay(transform.position, dir, Color.red);
            Debug.Log(raycast.collider.name);
        }

    }
}
