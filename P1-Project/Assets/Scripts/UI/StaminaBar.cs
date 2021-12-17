using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is stolen from brackeys DOI: https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=553s
public class StaminaBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxStamina(int stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
    }

    public void SetStamina(int stamina)
    {
        slider.value = stamina;
    }
}