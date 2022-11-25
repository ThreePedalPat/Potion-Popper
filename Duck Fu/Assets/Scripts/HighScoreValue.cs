using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreValue : MonoBehaviour
{
    public TextMeshProUGUI text;


    void Awake()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();


    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        text.SetText(PlayerPrefs.GetFloat("HighScore").ToString());
    }
}
