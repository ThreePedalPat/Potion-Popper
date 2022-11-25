using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();  
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health/100;
        slider.value = health/100;
    }

    public void SetHealth(float health)
    {
        slider.value = health/100;
    }


}
