using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatMenu : MonoBehaviour
{
    public Canvas cheatCanvas;
    public GameObject playerRef;
    public GameObject moneyCheatButtonRef;
    public Button moneyCheatButton;
    public GameObject healthCheatButtonRef;
    public Button healthCheatButton;
    public PlayerControls player;

    public bool gotMoney = false;

    private void Awake()
    {
        playerRef = GameObject.FindWithTag("Player");
        moneyCheatButtonRef = GameObject.FindWithTag("MoneyCheatButton");
        healthCheatButtonRef = GameObject.FindWithTag("HealthCheatButton");
        player = playerRef.GetComponent<PlayerControls>();
        moneyCheatButton = moneyCheatButtonRef.GetComponent<Button>();
        healthCheatButton = healthCheatButtonRef.GetComponent<Button>();
        cheatCanvas = GetComponent<Canvas>();
    }
    private void Start()
    {
        CheckCheatMenu();
    }

    void Update()
    {

    }

    public void OpenCheats()
    {
        cheatCanvas.enabled = true;
        player.gameIsPaused = true;
    }

    public void CloseCheats()
    {
        cheatCanvas.enabled = false;
        player.gameIsPaused = false;
    }

    public void CheckCheatMenu()
    {
        if(cheatCanvas.enabled)
        {
            cheatCanvas.enabled = false;
            
        }
    }

    public void FreeUpgrades()
    {
        gotMoney = true;
        moneyCheatButton.interactable = false;
    }
    public void NeverDie()
    {
        player.howFastYouDie = 0;
        healthCheatButton.interactable = false;
    }

}
