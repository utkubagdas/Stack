using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public static UnityEvent OnPlacePlatform = new UnityEvent();
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
