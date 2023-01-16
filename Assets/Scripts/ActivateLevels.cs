using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLevels : MonoBehaviour
{
    public GameObject sewers;
    public GameObject sewers2;
    public GameObject lights;
    public GameObject lights2;
    
    void Update()
    {
        checkLevels();
    }

    void checkLevels() 
    {
        if (PlayerPrefs.GetInt("CompletedWater") == 0) 
        {
            sewers.SetActive(false);
        } else if (PlayerPrefs.GetInt("CompletedWater") == 1) 
        {
            sewers2.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CompletedLight") == 0) 
        {
            lights.SetActive(false);
        } else if (PlayerPrefs.GetInt("CompletedLight") == 1) 
        {
            lights2.SetActive(false);
        }
    }
}
