using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Output : Component
{
    InputPort input;
    public GameObject IPort;
    public TextMeshPro outputText;
    [HideInInspector] public int outputValue;
    void Awake()
    {
        input = IPort.GetComponent<InputPort>();
    }

    
    void Update()
    {
        if (input.connected)
        {
            outputValue = input.GetPortValue();
            if (outputValue < int.MaxValue)
            {
                outputText.text = outputValue + "";
            } else
            {
                outputText.text = "";
                this.GetComponent<SpriteRenderer>().color = Color.white;
            }
            if (input.GetPortValue() == 1)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
            } else if (input.GetPortValue() == 0)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
            }
        } else
        {
            outputValue = int.MaxValue;
            outputText.text = "";
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public int getValue()
    {
        return outputValue;
    }
}
