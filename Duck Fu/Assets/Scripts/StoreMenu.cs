using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreMenu : MonoBehaviour
{
    public PlayerControls player;

    public Button resButton;
    public Button toughButton;
    public Button poppinButton;

    public GameObject playerRef;
    public GameObject resButtonRef;
    public GameObject toughButtonRef;
    public GameObject poppinButtonRef;
    public GameObject pauseMenuRef;

    public Canvas pauseCanvas;
    public Canvas storeCanvas;

    public BatteryPotion battPot;

    public BestPotion bestPot;

    public GoodPotion goodPot;

    public BasePotion basePot;

    public bool storeOpen;

    private void Awake()
    {
        playerRef = GameObject.FindWithTag("Player");
        resButtonRef = GameObject.FindWithTag("ResButton");
        toughButtonRef = GameObject.FindWithTag("ToughButton");
        poppinButtonRef = GameObject.FindWithTag("PoppinButton");
        pauseMenuRef = GameObject.FindWithTag("Pause Menu");

        player = playerRef.GetComponent<PlayerControls>();
        resButton = resButtonRef.GetComponent<Button>();
        toughButton = toughButtonRef.GetComponent<Button>();
        poppinButton = poppinButtonRef.GetComponent<Button>();
        pauseCanvas = pauseMenuRef.GetComponent<Canvas>();
        storeCanvas = GetComponent<Canvas>();

    }

    private void Start()
    {
        CheckStore();
    }

    private void Update()
    {
       
    }


    public void ResilienceUpgrade()
    {
        if(player.playerScore >= 1000)
        {
            player.playerScore -= 1000;
            player.resilient = true;
            resButton.interactable = false;
        }
    }

    public void ToughnessUpgrade()
    {
        if (player.playerScore >= 1000)
        {
            player.playerScore -= 1000;
            player.tough = true;
            toughButton.interactable = false;
            player.playerMaxHealth = 200;
        }
    }

    public void PotPopUpgrade()
    {
        if (player.playerScore >= 1000)
        {
            player.playerScore -= 1000;
            player.poppin = true;
            poppinButton.interactable = false;
            battPot.timeTilChargeOver = 5;
        }       
    }

    public void OpenStore()
    {
        storeCanvas.enabled = true;
        player.gameIsPaused = true;
        storeOpen = true;
    }

    public void CloseStore()
    {
        storeCanvas.enabled = false;
        player.gameIsPaused = false;
        storeOpen = false;
    }

    public void CheckStore()
    {
        storeOpen = false;
        if (storeCanvas.enabled)
        {
            storeCanvas.enabled = false;
        }
    }
}
