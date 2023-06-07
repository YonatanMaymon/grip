using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float temp;
    public Slider slider;


    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void MaxHealth(int health)
    {
        temp = slider.maxValue;
        slider.maxValue = health;
        slider.value += health - temp;
    }
}
