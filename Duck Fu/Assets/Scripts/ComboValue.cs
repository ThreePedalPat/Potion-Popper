using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ComboValue : MonoBehaviour
{
    public GameObject playerRef;
    public PlayerControls player;
    public TextMeshProUGUI text;

    void Awake()
    {
        playerRef = GameObject.FindWithTag("Player");
        player = playerRef.GetComponent<PlayerControls>();
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {
        text.SetText(player.potionsCaught.ToString());
    }
}
