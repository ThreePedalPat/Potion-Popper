using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BatteryPotion : Potion
{
    [SerializeField] public float timeTilChargeOver = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            healthScript.playerHealth = healthScript.playerMaxHealth;
            healthScript.healthBarUI.SetHealth(healthScript.playerHealth, healthScript.playerMaxHealth);
            healthScript.batteryPowered = true;
            healthScript.batteryPoweredTimeStamp = Time.time + timeTilChargeOver;
            healthScript.potionsCaught += 1;
            healthScript.healthElapsed = 0;
            spawnScript.alreadyDone = false;
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
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Ground")
        {
            audioScript.Play("PotionBreak");
            healthScript.potionsCaught = 0;
            healthScript.scoreMultiplier = 1;
            spawnScript.spawnedEnemies -= 1;
            spawnScript.alreadyDone = false;
            Destroy(gameObject);
        }

    }
}
