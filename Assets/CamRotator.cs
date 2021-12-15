using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotator : MonoBehaviour
{
    public bool canRotate = false;


    private void Update()
    {
        if (!canRotate)
            return;

        transform.Rotate(Vector3.up * 100 * Time.deltaTime);
    }
}
