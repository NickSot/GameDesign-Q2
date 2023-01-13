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
    void Awake()
    {
        input = IPort.GetComponent<InputPort>();
    }

    
    void Update()
    {
        if (input.connected)
        {
            outputText.text = input.GetPortValue() + "";
            if (input.GetPortValue() == 1)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
            } else
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
