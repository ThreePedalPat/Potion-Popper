using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoodPotion : Potion
{

    [SerializeField] public int baseScoreAmount = 50;
    [SerializeField] public int poppinScoreAmount = 75;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            //if()
            //{
                if (!healthScript.poppin)
                {
                    healthScript.playerScore += baseScoreAmount * healthScript.scoreMultiplier;
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
                    if (healthScript.potionsCaught >= 10)
                    {
                        healthScript.scoreMultiplier = 1.1f;

                        if (healthScript.potionsCaught >= 20)
                        {
                            healthScript.scoreMultiplier = 1.3f;

                            if (healthScript.potionsCaught > 29)
                            {
                                healthScript.scoreMultiplier = 1.5f;
                            }
                        }
                    }
                    spawnScript.spawnedEnemies -= 1;
                    spawnScript.alreadyDone = false;
                    Destroy(gameObject);
                //}
            }
            else if(healthScript.poppin)
            {
                healthScript.playerScore += poppinScoreAmount * healthScript.scoreMultiplier;
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
                if (healthScript.potionsCaught >= 10)
                {
                    healthScript.scoreMultiplier = 1.1f;

                    if (healthScript.potionsCaught >= 20)
                    {
                        healthScript.scoreMultiplier = 1.3f;

                        if (healthScript.potionsCaught > 29)
                        {
                            healthScript.scoreMultiplier = 1.5f;
                        }
                    }
                }
                spawnScript.spawnedEnemies -= 1;
                spawnScript.alreadyDone = false;
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Ground")
        {
            healthScript.potionsCaught = 0;
            healthScript.scoreMultiplier = 1;
            spawnScript.spawnedEnemies -= 1;
            spawnScript.alreadyDone = false;
            Destroy(gameObject);
        }
    }
}
