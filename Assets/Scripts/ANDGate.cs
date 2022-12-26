using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class ANDGate : Component
{
    Switch switchValue1;
    Switch switchValue2;
    InputPort input1;
    InputPort input2;
    public GameObject button1;
    public GameObject button2;
    public GameObject IPort1;
    public GameObject IPort2;
    private int getValue1;
    private int getValue2;
    private int output;

    void Awake()
    {
        switchValue1 = button1.GetComponent<Switch>();
        switchValue2 = button2.GetComponent<Switch>();
        input1 = IPort1.GetComponent<InputPort>();
        input2 = IPort2.GetComponent<InputPort>();
    }

    void Update()
    {
        if (input1.connected && input2.connected)
        {
            getValue1 = switchValue1.value;
            getValue2 = switchValue2.value;

            if (getValue1 == 1 && getValue2 == 1)
            {
                output = 1;
                Debug.Log("AND Gate works");
            }
            else
            {
                output = 0;
            }
            
        }
    }

}
