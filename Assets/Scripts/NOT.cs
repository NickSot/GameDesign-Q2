using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOT : Component
{
    private static string x = "xx";
    private static int getValue;
    private int output;
    void Start()
    {
       

    }

    void Update()
    {
        getValue = PlayerPrefs.GetInt(x);

        if (getValue == 0)
        {
            output = 1;
            
        } else 
        {
            output = 0;
        }
        Debug.Log(output);
    }
}
