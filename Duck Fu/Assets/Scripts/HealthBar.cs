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

    public void SetMaxHealth(float maxhealth)
    {
        if(maxhealth == 200)
        {
            slider.maxValue = maxhealth / 200;
            slider.value = maxhealth / 200;
        }
        else
        {
            slider.maxValue = maxhealth / 100;
            slider.value = maxhealth / 100;
        }
    }

    public void SetHealth(float health, float maxhealth)
    {
        if(maxhealth == 200)
        {
            slider.value = health / 200;
        }
        else
        {
            slider.value = health / 100;
        }

    }


}
