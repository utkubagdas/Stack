using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private DynamicPlatform platformPrefab;

    public void SpawnPlatform()
    {
        var cube = Instantiate(platformPrefab);
        cube.transform.position = new Vector3(DynamicPlatform.lastPlatform.transform.position.x, DynamicPlatform.lastPlatform.transform.position.y, DynamicPlatform.lastPlatform.transform.position.z + DynamicPlatform.lastPlatform.GetComponent<Renderer>().bounds.size.z);
    }
}
