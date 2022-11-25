using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;
    public GameObject playerRef;

    public float timeToSpawn;
    public float timeStamp;
    public float spawnedEnemies;
    public float spawnedTotal;

    public int randomNumber;
    public int randomPotion;

    public PlayerControls healthScript;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        playerRef = GameObject.FindWithTag("Player");
        healthScript = playerRef.GetComponent<PlayerControls>();
        timeStamp = Time.time + 2;
        spawnedEnemies = 0;
        spawnedTotal = 0;
        randomNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeStamp <= Time.time && spawnedEnemies < 1 && !healthScript.gameIsPaused)
        {
            RollANumber();
            if(randomNumber == 1)
            {
                SpawnRight();
            }
            if (randomNumber == 2)
            {
                SpawnMid();
            }
            if (randomNumber == 3)
            {
                SpawnLeft();
            }

        }

    }

    public void SpawnLeft()
    {
        RollAPotion();
        if (randomPotion == 1)
        {
            Instantiate(enemyPrefab, new Vector3(-6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            timeStamp = Time.time + 2;
            spawnedTotal += 1;
        }
        else if (randomPotion == 2)
        {
            Instantiate(enemy2Prefab, new Vector3(-6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            timeStamp = Time.time + 2;
            spawnedTotal += 1;
        }
        else if (randomPotion == 3)
        {
            Instantiate(enemy3Prefab, new Vector3(-6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            timeStamp = Time.time + 2;
            spawnedTotal += 1;
        }
        else if (randomPotion == 4)
        {
            Instantiate(enemy4Prefab, new Vector3(-6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            timeStamp = Time.time + 2;
            spawnedTotal += 1;
        }
    }

    public void SpawnMid()
    {
        RollAPotion();
        if (randomPotion == 1)
        {
            Instantiate(enemyPrefab, new Vector3(0f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            timeStamp = Time.time + 2;
            spawnedTotal += 1;
        }
        else if (randomPotion == 2)
        {
            Instantiate(enemy2Prefab, new Vector3(0f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            timeStamp = Time.time + 2;
            spawnedTotal += 1;
        }
        else if (randomPotion == 3)
        {
            Instantiate(enemy3Prefab, new Vector3(0f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            timeStamp = Time.time + 2;
            spawnedTotal += 1;
        }
        else if (randomPotion == 4)
        {
            Instantiate(enemy4Prefab, new Vector3(-6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            timeStamp = Time.time + 2;
            spawnedTotal += 1;
        }
    }

    public void SpawnRight()
    {
        RollAPotion();
        if (randomPotion == 1)
        {
            Instantiate(enemyPrefab, new Vector3(6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            timeStamp = Time.time + 2;
            spawnedTotal += 1;
        }
        else if (randomPotion == 2)
        {
            Instantiate(enemy2Prefab, new Vector3(6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            timeStamp = Time.time + 2;
            spawnedTotal += 1;
        }
        else if (randomPotion == 3)
        {
            Instantiate(enemy3Prefab, new Vector3(6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            timeStamp = Time.time + 2;
            spawnedTotal += 1;
        }
        else if (randomPotion == 4)
        {
            Instantiate(enemy4Prefab, new Vector3(-6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            timeStamp = Time.time + 2;
            spawnedTotal += 1;
        }
    }

    public void RollANumber()
    {
        randomNumber = Random.Range(1, 4);
    }

    public void RollAPotion()
    {
        randomPotion = Random.Range(1, 5);
    }
}
