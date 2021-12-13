using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public bool IsControlable;

    void Update()
    {
        if(IsControlable)
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }
}
