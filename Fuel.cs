using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI totalPointText;
    [SerializeField] Image fuelFillBar;

    float availibleFuel = 1f;
    float fuelDecreasePerSecond = 0.0001f;
    float increaseforOverTake = 0.01f;
   
 
    void Update()
    {
        FuelBarLevel();
    }

    private void FixedUpdate()
    {
        DecreaseFuel();
    }

    private void FuelBarLevel()
    {
        fuelFillBar.fillAmount = availibleFuel;
    }
    public void IncreaseFuel()
    {
        availibleFuel = availibleFuel + increaseforOverTake; 
    }

    private void DecreaseFuel()
    {
        availibleFuel = availibleFuel - fuelDecreasePerSecond;
    }
}
