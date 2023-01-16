using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Clock : Component
{
    [HideInInspector] public int clockValue;
    public TextMeshPro clockText;
    
    void Start()
    {
        clockValue = 0;
        InvokeRepeating("ClockSwitch", 0f, 0.1f);
        clockText.text = clockValue + "";
        
    }

    public void ClockSwitch()
    {
        if (clockValue == 0)
        {
            clockValue = 1;
        }
        else
        {
            clockValue = 0;
        }
        clockText.text = clockValue + "";
    }
}
