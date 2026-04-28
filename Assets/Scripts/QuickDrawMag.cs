using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDrawMag : MonoBehaviour, IMagHandler
{
    public Vector3 scaleValue;
    string attachmentType = "Magazine";

    private void Start()
    {
        scaleValue = this.transform.localScale;
    }

    public void UsingMag()
    {
        Debug.Log("Mag Type : Quick Draw Mag");
    }
}
