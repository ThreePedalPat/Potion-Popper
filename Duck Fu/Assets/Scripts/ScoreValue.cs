using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreValue : MonoBehaviour
{

    public TextMeshProUGUI text;
    public GameObject playerRef;
    public PlayerControls healthScript;

    // Start is called before the first frame update
    void Awake()
    {
        playerRef = GameObject.FindWithTag("Player");
        text = GetComponent<TMPro.TextMeshProUGUI>();
        healthScript = playerRef.GetComponent<PlayerControls>();

    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(healthScript.playerScore.ToString());
    }
}
