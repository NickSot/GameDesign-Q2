using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NOT : Component
{
    Switch switchValue;
    InputPort input;
    public GameObject button;
    public GameObject IPort;
    private int getValue;
    private int output;
    void Awake()
    {
        switchValue = button.GetComponent<Switch>();
        input = IPort.GetComponent<InputPort>();

    }

    void Update()
    {
        if (input.connected)
        {
            getValue = switchValue.value;

            if (getValue == 0)
            {
                output = 1;

            }
            else
            {
                output = 0;
            }
            Debug.Log(output);
        }
       
    }
}
