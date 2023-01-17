using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInformation : MonoBehaviour
{
    public GameObject message;

    void Start()
    {
        if (PlayerPrefs.GetInt("Loaded") == 0) 
        {
            message.SetActive(true);
        } 
    }

    public void close() 
    {
        message.SetActive(false);
    }
    
}
