using UnityEngine;
using UnityEngine.UI;
public class SwitcherMode : MonoBehaviour
{
    private Dropdown _dropdown;

    [SerializeField]
    private GameObject VrObject;

    [SerializeField]
    private GameObject Panorama;



    [SerializeField]

    private MouseMovement mouseMovement;

    private void Awake()
    {
        _dropdown = FindObjectOfType<Dropdown>();
        mouseMovement = FindObjectOfType<MouseMovement>();
        if (_dropdown == null || mouseMovement == null)
        {
            Debug.LogError("Not found DropDown or MouseMovement elements.");
            Destroy(this);
        }
        _dropdown.onValueChanged.AddListener(onValueChanged);
    }

    private void onValueChanged(int curOption)
    {
        switch (curOption)
        {
            case 0:
                {
                    VrObject.SetActive(true);
                    Panorama.SetActive(false);
                    mouseMovement.enabled = false;
                    break;
                }

            case 1:
                {
                    VrObject.SetActive(false);
                    Panorama.SetActive(true);
                    mouseMovement.enabled = false;
                    break;
                }

            case 2:
                {
                    VrObject.SetActive(false);
                    Panorama.SetActive(true);
                    mouseMovement.enabled = true;
                    break;
                }
        }
    }
}
