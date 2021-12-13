using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicPlatform : MonoBehaviour
{

    [SerializeField]
    public static DynamicPlatform curentPlatform { get; set; }
    public static DynamicPlatform lastPlatform { get; private set; }

    public DynamicPlatform showingLP;

    AudioSource audioSource;


    Vector3 pos1 = new Vector3(-3, 0, 0);
    Vector3 pos2 = new Vector3(3, 0, 0);

    public bool canMove = true;

    private void OnEnable()
    {
        if (lastPlatform == null)
            lastPlatform = GameObject.Find("First").GetComponent<DynamicPlatform>();
        
            curentPlatform = this;

        transform.localScale = lastPlatform.transform.localScale;
        showingLP = lastPlatform;

        audioSource = FindObjectOfType<AudioSource>();
    }

    private void Update()
    {
        //var pos = transform.position;
        if (canMove)
        {
            pos1.z = transform.position.z;
            pos2.z = transform.position.z;
            transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time, 1.0f));
        }
    }

   

    private void SlicePlatform(float diff, float direction)
    {
        float newXSize = lastPlatform.transform.localScale.x - Mathf.Abs(diff);
        float fallingBlockSize = transform.localScale.x - newXSize;

        float newXPosition = lastPlatform.transform.position.x + (diff / 2);
        transform.localScale = new Vector3(newXSize, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

        float cubeEdge = transform.position.x + (newXSize/2f * direction);
        float fallingBlockXPosition = cubeEdge + fallingBlockSize / 2f * direction;

        SpawnSlicedObj(fallingBlockXPosition, fallingBlockSize);

    }

    private void SpawnSlicedObj(float fallingBlockXPosition, float fallingBlockSize)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<Renderer>().sharedMaterial = GetComponent<Renderer>().sharedMaterial;
        cube.transform.localScale = new Vector3(fallingBlockSize, transform.localScale.y, transform.localScale.z);
        cube.transform.position = new Vector3(fallingBlockXPosition, transform.position.y, transform.position.z);

        cube.AddComponent<Rigidbody>();
        Destroy(cube.gameObject, 1f);
    }
    internal void Stop()
    {
        canMove = false;
        float diff = transform.position.x - lastPlatform.transform.position.x;
        
        
        if(Mathf.Abs(diff) >= lastPlatform.transform.localScale.x)
        {
            lastPlatform = null;
            curentPlatform = null;
            SceneManager.LoadScene(0);
        }

        if (diff <= 0.30f && diff >= -0.30f)
        {
            audioSource.pitch += 0.1f;
            audioSource.PlayOneShot(audioSource.clip);
        }
        else
        {
            audioSource.Stop();
            audioSource.pitch = 0.2f;
        }

        float direction = diff > 0 ? 1f : -1f;
        SlicePlatform(diff, direction);

        lastPlatform = this;
    }
}
