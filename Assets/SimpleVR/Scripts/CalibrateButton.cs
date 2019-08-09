using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CalibrateButton : MonoBehaviour
{
    private Button button;
    private VrController vrController;

    private void Start()
    {
        button = GetComponent<Button>();
        vrController = FindObjectOfType<VrController>();
        if (!vrController)
        {
            Debug.LogError("Vr Controller not found in scene");
            Destroy(this);
        }
        button.onClick.AddListener(Calibrate);
    }

    public void Calibrate()
    {
        vrController.Calibrate();
    }
}
