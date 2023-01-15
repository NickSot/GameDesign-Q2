using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNode : Component
{
    public OutputPort outputport;
    [HideInInspector] public int value;
    public bool checking;
    public int testValue;
    int i = 0;

    private void Start()
    {
        value = 0;
        this.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void ToggleValue() {
       outputport.currentValue = !outputport.currentValue;
        if (outputport.currentValue)
        {
            
            value = 1;
             
            this.GetComponent<SpriteRenderer>().color = Color.green;
        } else
        {
            
            value = 0;
            
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
        
    }
    
    public void setValue(int newValue)
    {

        //checking = true;
        this.testValue = newValue;
        //Debug.Log(i + ", " + testValue);
        i++;
    }
    
}
