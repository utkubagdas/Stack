using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
    }
}
