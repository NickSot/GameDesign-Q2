using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

public class CheckCircuit : MonoBehaviour
{
    public GameObject output;
    public InputNode inputNode;
    public InputNode inputNode2;
    public GameObject nextLevel;
    //public GameObject submit;
    public GameObject bulb;
    private int inputValue;
    private int inputValue2;
    private int outputValue;
    private int testLight = 0;
    public bool GameRunning;
    public bool testing;

    void Start()
    {
        bulb.GetComponent<SpriteRenderer>().color = Color.red;
        nextLevel.SetActive(false);
    }

    private void Update()
    {
       // outputValue = output.GetComponent<Output>().outputValue;
    }

    public void Submit()
    {
        //Time.timeScale = 0;
        testing = true;
        
        if (SceneManager.GetActiveScene().name == "NOTTutorial")
        {
            checkNOTTutorial();
        } else if (SceneManager.GetActiveScene().name == "LightBulb")
        {
            checkLightBulb();
            //UnityEngine.Debug.Log(testLight);
            if (testLight == 4)
            {
                bulb.GetComponent<SpriteRenderer>().color = Color.green;
                nextLevel.SetActive(true);
            } else
            {
                testLight = 0;
            }
        }
        //testing = false;
    }

    void checkNOTTutorial()
    {
        if (inputValue == 0)
        {
            if (outputValue == 1)
            {
                bulb.GetComponent<SpriteRenderer>().color = Color.green;
                nextLevel.SetActive(true);
            } 
        } else if (inputValue == 1)
        {
            if (outputValue == 0)
            {
                bulb.GetComponent<SpriteRenderer>().color = Color.green;
                nextLevel.SetActive(true);
            }
        }
    }

    void checkLightBulb()
    {
        inputNode.setValue(0);
        inputNode2.setValue(0);
        outputValue = output.GetComponent<Output>().outputValue;
        UnityEngine.Debug.Log("First: "+ outputValue);
        if (outputValue == 0)
        {
            testLight++;
        }
        inputNode.setValue(0);
        inputNode2.setValue(1);
        outputValue = output.GetComponent<Output>().outputValue;
        UnityEngine.Debug.Log("Second: " + outputValue);
        if (outputValue == 1)
        {
            testLight++;
        }
        inputNode.setValue(1);
        inputNode2.setValue(0);
        outputValue = output.GetComponent<Output>().outputValue;
        UnityEngine.Debug.Log("Third: " + outputValue);
        if (outputValue == 1)
        {
            testLight++;
        }
        inputNode.setValue(1);
        inputNode2.setValue(1);
        outputValue = output.GetComponent<Output>().outputValue;
        UnityEngine.Debug.Log("Fourth: " + outputValue);
        if (outputValue == 0)
        {
            testLight++;
        }
        //UnityEngine.Debug.Log("4" + testLight);
    }
}
