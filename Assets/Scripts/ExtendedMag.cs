using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedMag : MonoBehaviour, IMagHandler
{
    public Vector3 scaleValue;
    string attachmentType = "Magazine";

    private void Start()
    {
        scaleValue = this.transform.localScale;
    }

    public void UsingMag()
    {
        Debug.Log("Mag Type : Extended Mag");
    }
}
