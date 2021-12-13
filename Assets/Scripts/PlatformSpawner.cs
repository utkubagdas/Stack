using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private DynamicPlatform platformPrefab;
    public GameObject finishLine;
    float prefabScaleZ;
    float finishPosZ;
    int maxPlatformCount;
    int platformCount;
    float firstPlatformPosZ;

    private void Start()
    {
        firstPlatformPosZ = GameObject.Find("First").transform.position.x;
        prefabScaleZ = platformPrefab.transform.localScale.z;
        finishPosZ = finishLine.transform.position.z;

        maxPlatformCount = Convert.ToInt32(Mathf.Abs((firstPlatformPosZ - finishPosZ) / prefabScaleZ)) - 2;
    }

    public void SpawnPlatform()
    {
        if(platformCount >= maxPlatformCount)
        {
            GameManager.gameManager.platformFinished = true;
            return;
        }
        platformCount++;
        var cube = Instantiate(platformPrefab);
        cube.transform.position = new Vector3(DynamicPlatform.lastPlatform.transform.position.x, DynamicPlatform.lastPlatform.transform.position.y, DynamicPlatform.lastPlatform.transform.position.z + DynamicPlatform.lastPlatform.GetComponent<Renderer>().bounds.size.z);
        
    }
}
