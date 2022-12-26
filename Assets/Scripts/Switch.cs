using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public int value;
    public Text current;
    public GameObject btn;
    
    void Start()
    {
        value = 0;
        btn.GetComponent<Image>().color = Color.red;
        current.text = value + "";
        
    }

    private void SetValue(int value)
    {
        this.value = value;
    }

    private int GetValue()
    {
        return this.value;
    }

    public void switchValues()
    {
        
        if(value == 0)
        {
            value = 1;
            SetValue(value);
            current.text = value + "";
            btn.GetComponent<Image>().color = Color.green;     
        } else if (value == 1)
        {
            value = 0;
            SetValue(value);
            current.text = value + "";
            btn.GetComponent<Image>().color = Color.red;
           
        }
    }

    private void Update()
    {
        value = GetValue();
        
    }
}
