using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoXScope : MonoBehaviour, IScopeHandler
{
    public Vector3 scaleValue;
    string scopeType = "Scope";

    private void Start()
    {
        scaleValue = this.transform.localScale;
    }

    public void UsingScope()
    {
        Debug.Log("Scope Type : 2xScope");
    }
}
