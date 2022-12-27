using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Output : MonoBehaviour
{
    InputPort input;
    public GameObject IPort;
    public Text outputText;
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
