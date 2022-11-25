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

    public float playerHealth;
    [SerializeField] public float playerMaxHealth = 100;
    public int playerScore;

    [SerializeField] private float speed;

    public Spawner spawnScript;
    public GameObject spawnerRef;

    public HealthBar healthBarUI;
    public GameObject healthBar;

    private Rigidbody2D body;

    public bool resilient = false;
    public bool tough = false;
    public bool poppin = false;

    public float howFastYouDie = 0.05f;

    public float potionsCaught;
    public float highScore = 0;

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

        if (playerHealth > 0 && !gameIsPaused && !batteryPowered)
        {
            if (resilient)
            {
                playerHealth -= 0.03f;
                healthBarUI.SetHealth(playerHealth);
            }
            else
            {
                playerHealth -= 0.05f;
                healthBarUI.SetHealth(playerHealth);
            }
        }
        else if (playerHealth <= 0)
        {
            gameOverCanvas.enabled = true;
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
            storeCanvas.enabled = true;
            storeScript.storeOpen = true;
            gameIsPaused = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && storeScript.storeOpen)
        {
            storeCanvas.enabled = false;
            storeScript.storeOpen = false;
            gameIsPaused = false;
        }

        if(newHighScore)
        {
            PlayerPrefs.SetFloat("HighScore", highScore);
        }

    }

    private void FixedUpdate()
    {
        if(!gameIsPaused)
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
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

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
