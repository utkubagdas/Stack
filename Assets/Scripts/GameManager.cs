using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DynamicPlatform firstMovingPlatform;

    private void Start()
    {
        DynamicPlatform.curentPlatform = firstMovingPlatform;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(DynamicPlatform.curentPlatform != null)
                DynamicPlatform.curentPlatform.Stop();

            FindObjectOfType<PlatformSpawner>().SpawnPlatform();
        }
    }
}
