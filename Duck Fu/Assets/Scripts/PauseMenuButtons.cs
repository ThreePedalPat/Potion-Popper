using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuButtons : MonoBehaviour
{
    public bool gameIsPaused;
    public Canvas pauseCanvas;
    public PlayerControls controlScript;
    public GameObject playerRef;

    void Awake()
    {
        playerRef = GameObject.FindWithTag("Player");
        pauseCanvas = GetComponent<Canvas>();
        controlScript = playerRef.GetComponent<PlayerControls>();
    }

    private void Start()
    {
        CheckPauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void UnpauseGame()
    {
        pauseCanvas.enabled = false;
        controlScript.gameIsPaused = false;
        Time.timeScale = 1;
    }

    public void CheckPauseMenu()
    {
        if (pauseCanvas.enabled)
        {
            pauseCanvas.enabled = false;
        }
    }
}
