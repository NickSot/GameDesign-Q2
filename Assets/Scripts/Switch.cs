using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    private int value;
    public Text current;
    public GameObject btn;
    private static string currentValue = "xx";
    void Start()
    {
        value = 0;
        btn.GetComponent<Image>().color = Color.red;
        current.text = value + "";
        
    }

    public void switchValues()
    {

        if(value == 0)
        {
            value = 1;
            current.text = value + "";
            btn.GetComponent<Image>().color = Color.green;
           
            
            
        } else if (value == 1)
        {
            value = 0;
            current.text = value + "";
            btn.GetComponent<Image>().color = Color.red;
           
        }
    }

    private void Update()
    {
        PlayerPrefs.SetInt(currentValue, value);
        //Debug.Log(value);
    }



}
