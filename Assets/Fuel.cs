using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public Slider slider;

    public float fuel = 1;

    float initFuel;

    private void Awake()
    {
        initFuel = fuel;
        slider.maxValue = fuel;
    }

    private void LateUpdate()
    {
        fuel = Mathf.Min(fuel, initFuel);
        slider.value = fuel;
    }
}
