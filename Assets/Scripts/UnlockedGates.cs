using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UnlockedGates : MonoBehaviour
{
    public GameObject NOT;
    public GameObject AND;
    public GameObject OR;
    public GameObject message;
    void Start()
    {
        NOT.SetActive(false);
        AND.SetActive(false);
        OR.SetActive(false);
        checkScene();
    }

    void Unlocked() 
    {
        if (PlayerPrefs.GetFloat("") == 1) 
        {
            NOT.SetActive(true);
        } else if (PlayerPrefs.GetFloat("") == 2) 
        {
            NOT.SetActive(true);
            AND.SetActive(true);
        } else if (PlayerPrefs.GetFloat("") == 3) 
        {
            NOT.SetActive(true);
            AND.SetActive(true);
            OR.SetActive(true);
        }
    }

    void checkScene() 
    {
        if (SceneManager.GetActiveScene().name == "LightBulb" || SceneManager.GetActiveScene().name == "WaterDistribution" 
            || SceneManager.GetActiveScene().name == "LightBulb 1" || SceneManager.GetActiveScene().name == "WaterDistribution 1") 
        {
            if (PlayerPrefs.GetFloat("") < 3) 
            {
                message.SetActive(true);
            } 
        }
    }

    public void ClosePanel() 
    {
        message.SetActive(false);
    }

    void Update()
    {
        Unlocked();
    }
}
