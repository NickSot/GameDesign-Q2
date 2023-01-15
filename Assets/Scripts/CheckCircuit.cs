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
    public GameObject redo;
    
    void Start()
    {
        bulb.GetComponent<SpriteRenderer>().color = Color.red;
        nextLevel.SetActive(false);
        testing = false;
    }

    private void Update()
    {
       outputValue = output.GetComponent<Output>().outputValue;
    }

    public void Submit()
    {
        testing = true;
        
        StartCoroutine(TestLightBulb(0, 0, 0, 0f));
        StartCoroutine(TestLightBulb(0, 1, 1, 1f));
        StartCoroutine(TestLightBulb(1, 0, 1, 2f));
        StartCoroutine(TestLightBulb(1, 1, 0, 3f));
        // StartCoroutine(TestLightBulb(1, 1, 0, 4f));
        Invoke("method", 4f);
    }
    private IEnumerator TestLightBulb(int input_1, int input_2, int exp_Output, float time)
    {
        yield return new WaitForSeconds(time);

        inputNode.setValue(input_1);
        inputNode2.setValue(input_2);

        yield return new WaitForSeconds(0.1f);

        Debug.Log("Test: " + outputValue);

        // outputValue = output.GetComponent<Output>().outputValue;

        if (outputValue == exp_Output)
        {
            testLight++;
        }
    }

    public void NextLevel()
    {
        testing = false;
        testLight = 0;
        //SceneManager.LoadScene("Map");
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
}
