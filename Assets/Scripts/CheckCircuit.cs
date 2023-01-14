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
    public GameObject inputNode;
    public GameObject inputNode2;
    public GameObject nextLevel;
    public GameObject bulb;
    private int inputValue;
    private int inputValue2;
    private int outputValue;
    private string blueprint;

    void Start()
    {
        bulb.GetComponent<SpriteRenderer>().color = Color.red;
        nextLevel.SetActive(false);
    }
    void Update()
    {
        outputValue = output.GetComponent<Output>().outputValue;
        inputValue = inputNode.GetComponent<InputNode>().value;
        inputValue2 = inputNode2.GetComponent<InputNode>().value;
        if (SceneManager.GetActiveScene().name == "NOTTutorial")
        {
            checkNOTTutorial();
        } else if (SceneManager.GetActiveScene().name == "LightBulb")
        {
            blueprint = "(!i1 & i2) || (i1 & !i2)";
            checkLightBulb();
        }
            
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
        
    }


}
