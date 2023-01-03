using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Clock : MonoBehaviour
{
    [HideInInspector] public int clockValue;
    private string clk = "";
    public TextMeshPro clockText;
    
    void Start()
    {
        clockValue = 0;
        InvokeRepeating("ClockSwitch", 0f, 1f);
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

    private void CheckClockValue()
    {
        if (clockValue == 0)
        {
            PlayerPrefs.SetInt(clk, 5);
        }
    }

    private void Update()
    {
        CheckClockValue();
    }
}
