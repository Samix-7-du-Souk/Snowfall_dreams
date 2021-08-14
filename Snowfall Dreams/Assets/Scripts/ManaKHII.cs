using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaKHII : MonoBehaviour
{
    public Slider slider;
    public void SetMaxMana(int lowMana)
    {
        slider.maxValue = lowMana;
        slider.value = lowMana;
    }

    public void SetMana(int lowMana)
    {
        slider.value = lowMana;
    }
}