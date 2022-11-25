using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePotion : Potion
{
    [SerializeField] public int baseScoreAmount = 25;
    [SerializeField] public int poppinScoreAmount = 50;

    private void Awake()
    {
        playerRef = GameObject.FindWithTag("Player");
        healthScript = playerRef.GetComponent<PlayerControls>();
        spawnerRef = GameObject.FindWithTag("Spawn Manager");
        spawnScript = spawnerRef.GetComponent<Spawner>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            if (!healthScript.poppin)
            {
                healthScript.playerScore += baseScoreAmount;
                if (healthScript.playerScore > PlayerPrefs.GetFloat("HighScore"))
                {
                    healthScript.highScore = healthScript.playerScore;
                    healthScript.newHighScore = true;
                    //show new high score ui
                }
                if (healthScript.playerHealth <= 60 || healthScript.tough && healthScript.playerHealth <= 160)
                {
                    healthScript.playerHealth += 40;
                }
                else if (healthScript.playerMaxHealth == 100 && healthScript.playerHealth >= 60 || healthScript.playerMaxHealth == 200 && healthScript.playerHealth >= 160)
                {
                    healthScript.playerHealth = healthScript.playerMaxHealth;
                }
                healthScript.potionsCaught += 1;
                spawnScript.spawnedEnemies -= 1;
                Destroy(gameObject);
            }
            else if (healthScript.poppin)
            {
                healthScript.playerScore += poppinScoreAmount;
                if (healthScript.playerScore > PlayerPrefs.GetFloat("HighScore"))
                {
                    healthScript.highScore = healthScript.playerScore;
                    healthScript.newHighScore = true;
                    //show new high score ui
                }
                if (healthScript.playerHealth <= 60)
                {
                    healthScript.playerHealth += 40;
                }
                else
                {
                    healthScript.playerHealth = healthScript.playerMaxHealth;
                }
                healthScript.potionsCaught += 1;
                spawnScript.spawnedEnemies -= 1;
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Ground")
        {
            healthScript.potionsCaught = 0;
            spawnScript.spawnedEnemies -= 1;
            Destroy(gameObject);
        }
    }
}
