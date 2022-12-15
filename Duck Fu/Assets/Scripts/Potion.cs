using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Potion : MonoBehaviour
{
    public Rigidbody2D body;

    public GameObject playerRef;
    public PlayerControls healthScript;

    public Spawner spawnScript;
    public GameObject spawnerRef;

    public GameObject audioRef;
    public AudioManager audioScript;


    // Start is called before the first frame update
    void Awake()
    {
        playerRef = GameObject.FindWithTag("Player");
        healthScript = playerRef.GetComponent<PlayerControls>();
        spawnerRef = GameObject.FindWithTag("Spawn Manager");
        spawnScript = spawnerRef.GetComponent<Spawner>();
        body = GetComponent<Rigidbody2D>();
        audioRef = GameObject.FindWithTag("AudioManager");
        audioScript = audioRef.GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.gameIsPaused)
        {
            body.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            body.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    
}
