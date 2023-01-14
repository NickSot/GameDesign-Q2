using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using System.Threading;
using System.Runtime.ConstrainedExecution;

public class CheckCircuit : MonoBehaviour
{
    //public GameObject output;
    public InputNode inputNode;
    public InputNode inputNode2;
    public GameObject nextLevel;
    //public GameObject submit;
    public GameObject bulb;
    private int inputValue;
    private int inputValue2;
    private int outputValue;
    private int testLight = 0;
    public Output output;
    //public bool GameRunning;
    public bool testing;
    private int current;
    void Start()
    {
        bulb.GetComponent<SpriteRenderer>().color = Color.red;
        nextLevel.SetActive(false);
    }

    private void Update()
    {
       outputValue = output.GetComponent<Output>().outputValue;
        //Debug.Log(testing);
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
            Invoke("test1", 0.0f);
            Invoke("test2", 1.0f);
            Invoke("test3", 2.0f);
            Invoke("test4", 3.0f);
            Invoke("test5", 4.0f);

            //checkLightBulb();
            //testing = false;
            Invoke("method", 5.0f);
        }
        //testing = false;
    }

    void method() {
        UnityEngine.Debug.Log(testLight);
        if (testLight == 4)
        {
            bulb.GetComponent<SpriteRenderer>().color = Color.green;
            nextLevel.SetActive(true);
        } else
        {
            testLight = 0;
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
    void test1()
    {
        inputNode.setValue(0);
        inputNode2.setValue(0);
        current = outputValue;
        
        Debug.Log("Test 1: " + outputValue);

        // if (current == 0)
        // {
        //     testLight++;
        // }  
    }
    void test2()
    {
        inputNode.setValue(0);
        inputNode2.setValue(1);
        current = outputValue;
        Debug.Log("Test 2: " + outputValue);

        if (current == 0)
        {
            testLight++;
        }
    }
     void test3()
    {
        inputNode.setValue(1);
        inputNode2.setValue(0);
        current = outputValue;
        Debug.Log("Test 3: " + outputValue); 

        if (current == 1)
        {
            testLight++;
        }
    }

    void test4() 
    {
        inputNode.setValue(1);
        inputNode2.setValue(1);
        current = outputValue;
        Debug.Log("Test 4: " + outputValue);

        if (current == 1)
        {
            testLight++;
        }
    }

    void test5() 
    {
        inputNode.setValue(1);
        inputNode2.setValue(1);
        current = outputValue;
        Debug.Log("Test 4: " + outputValue);

        if (current == 0)
        {
            testLight++;
        }
    }
}
