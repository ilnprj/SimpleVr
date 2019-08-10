using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class CursorAnimation : MonoBehaviour
{
    private Raycaster raycaster;
    private Image fillProccess;
    private float durationAnim = 0.5f;
    private void Awake()
    {
        fillProccess = GetComponent<Image>();
        raycaster = FindObjectOfType<Raycaster>();
        if (raycaster != null)
        {
            raycaster.SelectStatusHandler += ChangeCursor;
        }
        else
        {
            Debug.LogError("Raycaster is not found!");
        }
    }

    private void OnDestroy()
    {
        if (raycaster != null)
        {
            raycaster.SelectStatusHandler -= ChangeCursor;
        }
    }

    private void ChangeCursor(bool selected)
    {
        float targetNum = selected ? 1.0f : 0f;
        StopCoroutine("LerpCoroutine");
        StartCoroutine(LerpCoroutine(targetNum));
    }

    private IEnumerator LerpCoroutine(float target)
    {
        float endTime = Time.unscaledTime + durationAnim;
        float start = fillProccess.fillAmount;
        while (Time.unscaledTime < endTime)
        {
            float t = (endTime - Time.unscaledTime) / durationAnim;
            t = 1 - t;
            fillProccess.fillAmount = Mathf.Lerp(start,target,t);
            yield return null;
        }
    }
}
