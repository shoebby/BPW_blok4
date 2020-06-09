using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Slider manaSlider;

    public void setMaxMana(float mana)
    {
        manaSlider.maxValue = mana;
        manaSlider.value = mana;
    }

    public void setMana(float mana)
    {
        manaSlider.value = mana;
    }
}
