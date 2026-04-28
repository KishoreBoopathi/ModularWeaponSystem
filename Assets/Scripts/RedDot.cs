using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDot : MonoBehaviour, IScopeHandler
{
    public Vector3 scaleValue;
    string attachmentType = "Scope";

    private void Start()
    {
        scaleValue = this.transform.localScale;
    }

    public void UsingScope()
    {
        Debug.Log("Scope Type : Red Dot");
    }
}
