using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour, ICollectable
{
    public GameObject CollectEffectPrefab;

    public virtual void Collect(Collector collector)
    {
        Destroy(gameObject); 
    }
}
