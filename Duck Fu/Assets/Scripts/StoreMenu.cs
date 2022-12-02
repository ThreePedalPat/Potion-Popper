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
    public Button invButton;
    public Button supButton;
    public Button embButton;

    public float potPopUpgradeCost = 1000;
    public float toughnessUpgradeCost = 1000;
    public float resilienceUpgradeCost = 1000;
    public float invUpgradeCost = 1000;
    public float supUpgradeCost = 1000;
    public float embUpgradeCost = 1000;
    public float invUpgradeAmount = 1;
    public float supUpgradeAmount = 10;
    public float embUpgradeAmount = 25;

    public GameObject playerRef;
    public GameObject resButtonRef;
    public GameObject toughButtonRef;
    public GameObject poppinButtonRef;
    public GameObject pauseMenuRef;
    public GameObject cheatMenuRef;
    public GameObject invButtonRef;
    public GameObject supButtonRef;
    public GameObject embButtonRef;

    public Canvas pauseCanvas;
    public Canvas storeCanvas;

    public BatteryPotion battPot;

    public BestPotion bestPot;

    public GoodPotion goodPot;

    public BasePotion basePot;

    public CheatMenu cheats;

    public bool storeOpen;

    private void Awake()
    {
        playerRef = GameObject.FindWithTag("Player");
        resButtonRef = GameObject.FindWithTag("ResButton");
        toughButtonRef = GameObject.FindWithTag("ToughButton");
        poppinButtonRef = GameObject.FindWithTag("PoppinButton");
        pauseMenuRef = GameObject.FindWithTag("Pause Menu");
        cheatMenuRef = GameObject.FindWithTag("CheatMenu");
        invButtonRef = GameObject.FindWithTag("invButton");
        supButtonRef = GameObject.FindWithTag("supButton");
        embButtonRef = GameObject.FindWithTag("embButton");

        player = playerRef.GetComponent<PlayerControls>();
        cheats = cheatMenuRef.GetComponent<CheatMenu>();
        resButton = resButtonRef.GetComponent<Button>();
        toughButton = toughButtonRef.GetComponent<Button>();
        poppinButton = poppinButtonRef.GetComponent<Button>();
        invButton = invButtonRef.GetComponent<Button>();
        supButton = supButtonRef.GetComponent<Button>();
        embButton = embButtonRef.GetComponent<Button>();
        pauseCanvas = pauseMenuRef.GetComponent<Canvas>();
        storeCanvas = GetComponent<Canvas>();

    }

    private void Start()
    {
        CheckStore();
        CheckButtons();
    }

    private void Update()
    {
       
    }


    public void ResilienceUpgrade()
    {
        if(!cheats.gotMoney)
        {
            if (player.playerScore >= resilienceUpgradeCost)
            {
                player.playerScore -= resilienceUpgradeCost;
                player.resilient = true;
                resButton.interactable = false;
            }
        }
        else
        {
            player.resilient = true;
            resButton.interactable = false;
        }
    }

    public void ToughnessUpgrade()
    {
        if(!cheats.gotMoney)
        {
            if (player.playerScore >= toughnessUpgradeCost)
            {
                player.playerScore -= toughnessUpgradeCost;
                player.tough = true;
                toughButton.interactable = false;
                player.playerMaxHealth = 200;
            }
        }
        else
        {
            player.tough = true;
            toughButton.interactable = false;
            player.playerMaxHealth = 200;
        }
        
        
    }

    public void PotPopUpgrade()
    {
        if(!cheats.gotMoney)
        {
            if (player.playerScore >= potPopUpgradeCost)
            {
                player.playerScore -= potPopUpgradeCost;
                player.poppin = true;
                poppinButton.interactable = false;
                battPot.timeTilChargeOver = 5;
            }
        }
        else
        {
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

    public void CheckButtons()
    {
        invButton.interactable = true;
        supButton.interactable = false;
        embButton.interactable = false;
    }

    public void PotionInvestor()
    {
        if (!cheats.gotMoney)
        {
            if (player.playerScore >= invUpgradeCost)
            {
                player.playerScore -= invUpgradeCost;
                player.investor = true;
                invButton.interactable = false;
                supButton.interactable = true;
                player.scorePerSecond = invUpgradeAmount;
            }
        }
        else
        {
            player.investor = true;
            invButton.interactable = false;
            supButton.interactable = true;
            player.scorePerSecond = invUpgradeAmount;
        }
    }

    public void PotionSupplier()
    {
        if (!cheats.gotMoney)
        {
            if (player.playerScore >= supUpgradeCost)
            {
                player.playerScore -= supUpgradeCost;
                player.supplier = true;
                supButton.interactable = false;
                embButton.interactable = true;
                player.scorePerSecond = supUpgradeAmount;
            }
        }
        else
        {
            player.supplier = true;
            supButton.interactable = false;
            embButton.interactable = true;
            player.scorePerSecond = supUpgradeAmount;
        }
    }

    public void PotionEmbezzler()
    {
        if (!cheats.gotMoney)
        {
            if (player.playerScore >= embUpgradeCost)
            {
                player.playerScore -= embUpgradeCost;
                player.embezzler = true;
                embButton.interactable = false;
                player.scorePerSecond = embUpgradeAmount;
            }
        }
        else
        {
            player.embezzler = true;
            embButton.interactable = false;
            player.scorePerSecond = embUpgradeAmount;
        }
    }
}
