using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public System.Action<bool> SelectStatusHandler = delegate { };
    private bool hit = default;
    public bool Hit
    {
        get
        {
            return hit;
        }

        set
        {
            if (hit != value)
            {
                SelectStatusHandler?.Invoke(value);
                if (_targetManager!=null)
                _targetManager.HandlingTarget(raycast.collider.gameObject);
            }
            hit = value;
        }
    }

    [SerializeField]
    private float maxDistanceRay = 10f;
    private RaycastHit raycast;
    private Vector3 dir = default;
    private ITargetManager _targetManager;
    private void Awake()
    {
        _targetManager = GetComponent<ITargetManager>();

        if (_targetManager == null)
        {
            Debug.LogWarning("Target Manager is not found! Please check the it.");
        }
    }

    private void FixedUpdate()
    {
        dir = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, dir, out raycast, maxDistanceRay))
        {
            Hit = true;
#if UNITY_EDITOR
            Debug.DrawRay(transform.position, dir, Color.red);
#endif
        }
        else
        {
            Hit = false;
        }
    }
}
