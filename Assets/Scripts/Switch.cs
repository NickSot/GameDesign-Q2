using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    private int value;
    public Text current;
    public GameObject btn;
    private string currentValue = "";
    void Start()
    {
        value = 0;
        btn.GetComponent<Image>().color = Color.red;
        current.text = value + "";
        PlayerPrefs.SetInt(currentValue, value);
    }

    public void switchValues()
    {
        Debug.Log("xxx");

        if(value == 0)
        {
            value = 1;
            current.text = value + "";
            btn.GetComponent<Image>().color = Color.green;
            PlayerPrefs.SetInt(currentValue, value);
            
            
        } else if (value == 1)
        {
            value = 0;
            current.text = value + "";
            btn.GetComponent<Image>().color = Color.red;
            PlayerPrefs.SetInt(currentValue, value);
        }
    }

    
    
}
