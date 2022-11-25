using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPotion : Potion
{
    [SerializeField] public float timeTilChargeOver = 3;

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
            healthScript.playerHealth = healthScript.playerMaxHealth;
            healthScript.healthBarUI.SetHealth(healthScript.playerHealth);
            healthScript.batteryPowered = true;
            healthScript.batteryPoweredTimeStamp = Time.time + timeTilChargeOver;
            healthScript.potionsCaught += 1;
            spawnScript.spawnedEnemies -= 1;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Ground")
        {
            healthScript.potionsCaught = 0;
            spawnScript.spawnedEnemies -= 1;
            Destroy(gameObject);
        }

    }
}
