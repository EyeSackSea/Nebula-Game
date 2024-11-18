using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnInterval = 50f;
    private float spawnTimer = 0f;
    private int spawnType = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnTimer += 1;
        if (spawnInterval >= 10)
        {
            spawnInterval -= .01f;
            
        }
        if (spawnTimer >= spawnInterval)
        {
            SpawnObjects();
            spawnTimer = 0;
           
        }
    }

    void SpawnObjects()
    {
        Vector3 spawnLocation = new Vector3(10, 0, Random.Range(-5, 5));
        int spawnVar = Random.Range(0, 100);
        if(spawnVar >= 50)
        {
            spawnType = 0;
        } else if(spawnVar >= 20)
        {
            spawnType = 1;
        } else if(spawnVar >= 8)
        {
            spawnType = 2;
        }
        else
        {
            spawnType = 3;
        }
        int index = spawnType;
        Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        Vector3 starLocation = new Vector3(10, 0, Random.Range(-5, 5));
        Instantiate(objectPrefabs[4], starLocation, objectPrefabs[4].transform.rotation);
    }
}
