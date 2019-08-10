using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetManager 
{
    void SelectTarget(GameObject gameObject);

    void DeselectTarget();
}
