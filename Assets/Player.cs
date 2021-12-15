using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    PlayerController playerController;
    PlayerController PlayerController { get { return (playerController == null) ? playerController = GetComponent<PlayerController>() : playerController; } }

    public CinemachineVirtualCamera finishCam;
    //3 3.5 7
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FinishLine"))
        {
            finishCam.Priority = 11;
            //finishCam.Follow = PlayerController.gameObject.transform;
            //finishCam.LookAt = PlayerController.gameObject.transform;
            PlayerController.GetComponentInChildren<Animator>().SetTrigger("Dance");
            PlayerController.IsControlable = false;
            GetComponentInChildren<CamRotator>().enabled = true;
            GetComponentInChildren<CamRotator>().canRotate = true;
        }
        if(other.CompareTag("Fall"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
