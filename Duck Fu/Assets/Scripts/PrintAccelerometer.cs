using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintAccelerometer : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(Input.acceleration.x.ToString());
    }
}
