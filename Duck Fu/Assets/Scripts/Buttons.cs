using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject playerRef;
    public bool onLeft;
    public bool onRight;
    public Canvas gameCanvas;

    // Start is called before the first frame update
    void Awake()
    {
        playerRef = GameObject.FindWithTag("Player");
        gameCanvas = GetComponent<Canvas>();
        onLeft = true;
        onRight = false;
    }

    private void Start()
    {
        if (gameCanvas.enabled == false)
        {
            gameCanvas.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveRight()
    {
        if(onLeft)
        {
            playerRef.transform.position = new Vector3(0f, -3.2f, 0);
            onLeft = false;
        }
        else if(!onLeft && !onRight)
        {
            playerRef.transform.position = new Vector3(6.6f, -3.2f, 0);
            onRight = true;
        }
        else
        {
            return;
        }
    }

    public void MoveLeft()
    {
        if (onRight)
        {
            playerRef.transform.position = new Vector3(0f, -3.2f, 0);
            onRight = false;
        }
        else if (!onRight && !onLeft)
        {
            playerRef.transform.position = new Vector3(-6.6f, -3.2f, 0);
            onLeft = true;
        }
        else
        {
            return;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();

    }
}
