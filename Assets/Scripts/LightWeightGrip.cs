using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWeightGrip : MonoBehaviour, IGripHandler
{
    public Vector3 scaleValue;
    string attachmentType = "Grip";

    private void Start()
    {
        scaleValue = this.transform.localScale;
    }

    public void UsingGrip()
    {
        Debug.Log("Grip Type : LightWeight Grip");
    }
}
