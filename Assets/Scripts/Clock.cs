using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Clock : MonoBehaviour
{
    [HideInInspector] public int clockValue;
    //public GameObject clock;
    public Text clockText;

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
}
