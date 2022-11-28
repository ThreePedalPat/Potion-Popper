using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaxHealthValue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject playerRef;
    public PlayerControls healthScript;

    private void Awake()
    {
        playerRef = GameObject.FindWithTag("Player");
        healthScript = playerRef.GetComponent<PlayerControls>();
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {
        text.SetText(healthScript.playerMaxHealth.ToString());
    }

}
