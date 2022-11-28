using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LivesValue : MonoBehaviour
{
    public GameObject playerRef;
    public TextMeshProUGUI text;
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
        text.SetText(healthScript.playerHealth.ToString());
    }
}
