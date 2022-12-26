using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Windows;

public class ANDGate : Component
{
    InputPort input1;
    InputPort input2;
    public GameObject IPort1;
    public GameObject IPort2;
    private int getValue1;
    private int getValue2;
    [HideInInspector] public int output;

    void Awake()
    {
        input1 = IPort1.GetComponent<InputPort>();
        input2 = IPort2.GetComponent<InputPort>();
    }

    void Update()
    {
        if (input1.connected && input2.connected)
        {
            getValue1 = input1.GetPortValue();
            getValue2 = input2.GetPortValue();
            

            if (getValue1 == 1 && getValue2 == 1)
            {
               output = 1;
               Debug.Log("AND output: " + output);
            }
            else
            {
                output = 0;
                Debug.Log("AND output: " + output);
            }
            
        }
    }
}
