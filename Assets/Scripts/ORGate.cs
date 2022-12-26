using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORGate : Component
{
    // Start is called before the first frame update
    public static string s = "";

    public static int key;

    public void Start()
    {
        key = PlayerPrefs.GetInt(s);   
    }

    public void Update()
    {
        if (key == 0)
        {
            Debug.Log("It works");
        }

        Debug.Log("It does not work");

    }
}
