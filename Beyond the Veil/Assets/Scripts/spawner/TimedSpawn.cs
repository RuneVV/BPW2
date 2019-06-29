using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    //public List<GameObject> spawner;
    public GameObject[] spawner;
    public List<GameObject> hasBeenSpawned;

    public bool stopSpawning = false;
    public bool firstHasSpawned = false;

    public float spawnTime;
    public float spawnDelay;



    int randomInt;

    public float fallSpeedSpawner;

    public float beginSpeed = 2.0f;

    public float optel = 1f;

    public float maxSpeed = 11.0f;



    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        fallSpeedSpawner = beginSpeed;
    }

    public void Update()
    {
        if (firstHasSpawned)
        {
            //fallSpeedSpawner = beginSpeed + (optel * Time.deltaTime);
            if (fallSpeedSpawner < maxSpeed)
            {
                fallSpeedSpawner += optel;
            }
            

            GameObject.FindGameObjectsWithTag("bell");

            foreach (GameObject bell in hasBeenSpawned)
            {
                bell.GetComponent<bellfalldown>().fallSpeed = fallSpeedSpawner;
            }
        }
        
    }

    public void SpawnObject()
    {
        randomInt = Random.Range(0, spawner.Length);

        

        GameObject spawnedBell = Instantiate(spawner[randomInt], transform.position, transform.rotation);
        hasBeenSpawned.Add(spawnedBell);
        firstHasSpawned = true;
      
            

        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }

    public void stopSpawn()
    {
        CancelInvoke("SpawnObject");
    }

}
