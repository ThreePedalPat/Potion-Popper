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
    public float spawnElapsed;
    public float spawnedEnemies;
    public float spawnedTotal;
    public float secondsToSpawn = 1;
    public float baseDifficultyPoint = 30;

    public int randomNumber;
    public int randomPotion;

    public bool alreadyDone;

    public PlayerControls healthScript;


    // Start is called before the first frame update
    void Start()
    {
        spawnedEnemies = 0;
        spawnedTotal = 0;
        randomNumber = 0;
        secondsToSpawn = 1;
        alreadyDone = false;
    }

    private void Awake()
    {
        playerRef = GameObject.FindWithTag("Player");
        healthScript = playerRef.GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!healthScript.gameIsPaused)
        {
            spawnElapsed += Time.deltaTime;
        }

        if(spawnedTotal >= baseDifficultyPoint && !healthScript.SSS && spawnedEnemies > 1)
        {
            secondsToSpawn = 2;
            if(spawnedTotal >= baseDifficultyPoint + 20 && !healthScript.SSS && spawnedEnemies > 1)
            {
                secondsToSpawn = 3;
                if (spawnedTotal >= baseDifficultyPoint + 40 && !healthScript.SSS && spawnedEnemies > 1)
                {
                    secondsToSpawn = 4;
                    if (spawnedTotal >= baseDifficultyPoint + 60 && !healthScript.SSS && spawnedEnemies > 1)
                    {
                        secondsToSpawn = 5;
                        if (spawnedTotal >= baseDifficultyPoint + 80 && !healthScript.SSS && spawnedEnemies > 1)
                        {
                            secondsToSpawn = 6;
                            if (spawnedTotal >= baseDifficultyPoint + 100 && !healthScript.SSS && spawnedEnemies > 1)
                            {
                                secondsToSpawn = 7;
                            }
                        }
                    }
                }

            }
        }

        if (spawnElapsed >= secondsToSpawn && !healthScript.gameIsPaused)
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
        spawnElapsed = 0;
        if (randomPotion == 1)
        {
            Instantiate(enemyPrefab, new Vector3(-6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            spawnedTotal += 1;
        }
        else if (randomPotion == 2)
        {
            Instantiate(enemy2Prefab, new Vector3(-6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            spawnedTotal += 1;
        }
        else if (randomPotion == 3)
        {
            Instantiate(enemy3Prefab, new Vector3(-6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            spawnedTotal += 1;
        }
        else if (randomPotion == 4)
        {
            Instantiate(enemy4Prefab, new Vector3(-6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            spawnedTotal += 1;
        }
    }

    public void SpawnMid()
    {
        RollAPotion();
        spawnElapsed = 0;
        if (randomPotion == 1)
        {
            Instantiate(enemyPrefab, new Vector3(0f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            spawnedTotal += 1;
        }
        else if (randomPotion == 2)
        {
            Instantiate(enemy2Prefab, new Vector3(0f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            spawnedTotal += 1;
        }
        else if (randomPotion == 3)
        {
            Instantiate(enemy3Prefab, new Vector3(0f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            spawnedTotal += 1;
        }
        else if (randomPotion == 4)
        {
            Instantiate(enemy4Prefab, new Vector3(-6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            spawnedTotal += 1;
        }
    }

    public void SpawnRight()
    {
        RollAPotion();
        spawnElapsed = 0;
        if (randomPotion == 1)
        {
            Instantiate(enemyPrefab, new Vector3(6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            spawnedTotal += 1;
        }
        else if (randomPotion == 2)
        {
            Instantiate(enemy2Prefab, new Vector3(6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            spawnedTotal += 1;
        }
        else if (randomPotion == 3)
        {
            Instantiate(enemy3Prefab, new Vector3(6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
            spawnedTotal += 1;
        }
        else if (randomPotion == 4)
        {
            Instantiate(enemy4Prefab, new Vector3(-6.6f, 3.6f, 0f), Quaternion.identity);
            spawnedEnemies++;
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
