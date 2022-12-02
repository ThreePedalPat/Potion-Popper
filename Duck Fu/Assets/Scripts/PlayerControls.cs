using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControls : MonoBehaviour
{
    public GameObject pauseMenuRef;
    public Canvas pauseCanvas;
    public Canvas storeCanvas;

    public GameObject storeMenuRef;
    public StoreMenu storeScript;

    public Canvas gameOverCanvas;
    public GameObject gameOverMenuRef;
    public bool gameIsPaused;
    public bool gameIsLost;
    public bool batteryPowered = false;
    public float batteryPoweredTimeStamp;
    public float batteryPoweredLength = 3;

    public int playerHealth;
    [SerializeField] public int playerMaxHealth = 100;
    public float playerScore;

    [SerializeField] private float droidSpeed = 35;
    [SerializeField] private float pcSpeed = 25;

    public Spawner spawnScript;
    public GameObject spawnerRef;

    public HealthBar healthBarUI;
    public GameObject healthBar;

    private Rigidbody2D body;

    public float healthElapsed; //health timer
    public float elapsed; //score timer
    public float scorePerSecond;

    public bool resilient = false;
    public bool tough = false;
    public bool poppin = false;
    public bool investor = false;
    public bool supplier = false;
    public bool embezzler = false;

    public int howFastYouDie = 12;
    public int howSlowYouDie = 6;

    public float potionsCaught;
    public float highScore = 0;
    public float scoreMultiplier = 1;

    public bool newHighScore;

    // Start is called before the first frame update
    void Awake()
    {
        spawnerRef = GameObject.FindWithTag("Spawn Manager");
        pauseMenuRef = GameObject.FindWithTag("Pause Menu");
        gameOverMenuRef = GameObject.FindWithTag("GameOverMenu");
        storeMenuRef = GameObject.FindWithTag("Store");
        healthBar = GameObject.FindWithTag("HealthBar");

        spawnScript = spawnerRef.GetComponent<Spawner>();
        pauseCanvas = pauseMenuRef.GetComponent<Canvas>();
        storeCanvas = storeMenuRef.GetComponent<Canvas>();
        storeScript = storeMenuRef.GetComponent<StoreMenu>();
        gameOverCanvas = gameOverMenuRef.GetComponent<Canvas>();
        body = GetComponent<Rigidbody2D>();
        healthBarUI = healthBar.GetComponent<HealthBar>();
    }

    private void Start()
    {
        gameIsPaused = false;
        playerHealth = playerMaxHealth;
        healthBarUI.SetMaxHealth(playerMaxHealth);
        newHighScore = false;
        scoreMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused)
        {
            pauseCanvas.enabled = true;
            gameIsPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused)
        {
            UnpauseGame();
        }

        if(resilient)
        {
            storeScript.resButton.interactable = false;
        }

        if (poppin)
        {
            storeScript.poppinButton.interactable = false;
        }

        if (tough)
        {
            storeScript.toughButton.interactable = false;
        }

        if (playerHealth > 0 && !gameIsPaused && !batteryPowered)
        {
            healthBarUI.SetHealth(playerHealth, playerMaxHealth);
            healthElapsed += Time.deltaTime;
            if(healthElapsed >= 1)
            {
                if(resilient && healthElapsed >= 1)
                {
                    playerHealth -= howSlowYouDie;
                    healthElapsed = 0;
                }
                else
                {
                    playerHealth -= howFastYouDie;
                    healthElapsed = 0;
                }
            }
        }

        if(!gameIsPaused && playerHealth > 0)
        {
            elapsed += Time.deltaTime;
            ScorePerSecond();
        }

        
        if (playerHealth <= 0)
        {
            gameOverCanvas.enabled = true;
            gameIsPaused = true;
            Time.timeScale = 0;
        }

        if(Time.timeScale == 0 && !gameIsPaused)
        {
            Time.timeScale = 1;
        }

        if(batteryPowered && batteryPoweredTimeStamp <= Time.time)
        {
            batteryPowered = false;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            storeScript.OpenStore();
        }

        if(newHighScore)
        {
            PlayerPrefs.SetFloat("HighScore", highScore);
        }

    }

    private void FixedUpdate()
    {
        if(!gameIsPaused && Input.GetAxis("Horizontal") != 0)
        { 
           body.velocity = new Vector2(Input.GetAxis("Horizontal") * pcSpeed, body.velocity.y);   
        }
        else if(!gameIsPaused)
        {
            if(Input.acceleration.x >= 0.08 || Input.acceleration.x <= -0.08)
            {
                body.velocity = new Vector2(Input.acceleration.x * droidSpeed, body.velocity.y);
            }

        }
    }

    public void UnpauseGame()
    {
        pauseCanvas.enabled = false;
        gameIsPaused = false;
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        pauseCanvas.enabled = true;
        gameIsPaused = true;
    }

    public void ScorePerSecond()
    {
        if(elapsed >= 1)
        {
            playerScore += scorePerSecond;
            elapsed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
