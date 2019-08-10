using UnityEngine;

public class ExampleTargetManager : MonoBehaviour, ITargetManager
{
    private GameObject target;

    [SerializeField]
    private Material selectedMaterial;

    [SerializeField]
    private Material deselectedMaterial;

    public void SelectTarget(GameObject gameObject)
    {
        target = gameObject;
        if (target.GetComponent<Target>())
        {
            target.GetComponent<Renderer>().material = selectedMaterial;
        }
    }

    public void DeselectTarget()
    {
        if (target.GetComponent<Target>())
        {
            target.GetComponent<Renderer>().material = deselectedMaterial;
            target = null;
        }
    }
}
