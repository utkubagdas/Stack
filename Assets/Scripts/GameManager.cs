using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public DynamicPlatform firstMovingPlatform;
    PlayerController playerController;
    public bool platformFinished = false;

    private void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
    }

    private void Start()
    {
        DynamicPlatform.curentPlatform = firstMovingPlatform;
    }

    private void Update()
    {
        if (platformFinished)
            return;

        if(Input.GetMouseButtonDown(0))
        {
            if(DynamicPlatform.curentPlatform != null)
                DynamicPlatform.curentPlatform.Stop();

            FindObjectOfType<PlatformSpawner>().SpawnPlatform();
            LevelStart();
        }
    }

    private void LevelStart()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerController.IsControlable = true;
        playerController.GetComponentInChildren<Animator>().SetTrigger("Run");
    }
}
