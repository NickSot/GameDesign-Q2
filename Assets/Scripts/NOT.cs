using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NOT : Component
{
    InputPort input;
    public GameObject IPort;
    private int getValue;
    [HideInInspector] public int output;

    void Awake()
    {
        input = IPort.GetComponent<InputPort>();

    }

    void Update()
    {

        if (input.connected)
        {
            
            getValue = input.GetPortValue();
            

            if (getValue == 0)
            {
                output = 1;
            }
            else
            {
                output = 0;
            }

        }
       
    }
}
