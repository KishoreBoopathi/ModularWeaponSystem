using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compensator : MonoBehaviour, IMuzzleHandler
{
    public Vector3 scaleValue;
    string attachmentType = "Muzzle";

    private void Start()
    {
        scaleValue = this.transform.localScale;
    }

    public void UsingMuzzle()
    {
        Debug.Log("Muzzle Type : Compensator");
    }
}
