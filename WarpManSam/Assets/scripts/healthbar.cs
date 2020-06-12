using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Slider ChargesSlider;

    public void setMaxCharges(float mana)
    {
        ChargesSlider.maxValue = mana;
        ChargesSlider.value = mana;
    }

    public void setCharges(float mana)
    {
        ChargesSlider.value = mana;
    }
}
