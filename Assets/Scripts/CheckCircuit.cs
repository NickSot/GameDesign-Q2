using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using System.Threading;
using System.Runtime.ConstrainedExecution;

public class CheckCircuit : MonoBehaviour
{
    public InputNode inputNode;
    public InputNode inputNode2;
    public GameObject nextLevel;
    public GameObject bulb;
    private int outputValue;
    private int testLight = 0;
    public Output output;
    public bool testing;
    private int current;
    public GameObject redo;
    void Start()
    {
        bulb.GetComponent<SpriteRenderer>().color = Color.red;
        nextLevel.SetActive(false);
    }

    private void Update()
    {
       outputValue = output.GetComponent<Output>().outputValue;
    }

    public void Submit()
    {
        testing = true;
        
        if (SceneManager.GetActiveScene().name == "LightBulb")
        {
            Invoke("test1", 0.0f);
            Invoke("test2", 0.1f);
            Invoke("test3", 0.2f);
            Invoke("test4", 0.3f);
            Invoke("test5", 0.4f);
            Invoke("method", 0.5f);
        }
    }

    public void Redo()
    {
        redo.SetActive(false);
        testing = false;
    }

    void method() {
        Debug.Log(testLight);
        if (testLight == 4)
        {
            bulb.GetComponent<SpriteRenderer>().color = Color.green;
            nextLevel.SetActive(true);
        } else
        {
            testLight = 0;
            redo.SetActive(true);
        }
    }
    void test1()
    {
        inputNode.setValue(0);
        inputNode2.setValue(0);
        current = outputValue;
        
        Debug.Log("Test 1: " + outputValue);
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
