using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuButtons : MonoBehaviour
{
    public GameObject gameOverMenuRef;
    public GameObject pauseMenuRef;

    public Canvas gameOverCanvas;

    public PauseMenuButtons pauseScript;

    public bool gameIsPaused;

    void Awake()
    {
        gameOverMenuRef = GameObject.FindWithTag("GameOverMenu");
        pauseMenuRef = GameObject.FindWithTag("Pause Menu");
        pauseScript = gameObject.GetComponent<PauseMenuButtons>();
        gameOverCanvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        CheckGameOverMenu();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CheckGameOverMenu()
    {
        if (gameOverCanvas.enabled)
        {
            gameOverCanvas.enabled = false;
        }
    }
}
