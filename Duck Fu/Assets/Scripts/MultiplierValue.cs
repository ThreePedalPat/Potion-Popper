using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultiplierValue : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        text.SetText(player.scoreMultiplier.ToString());
    }
}
