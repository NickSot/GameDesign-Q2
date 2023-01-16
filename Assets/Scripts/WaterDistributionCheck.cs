using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WaterDistributionCheck : MonoBehaviour
{
    public InputNode inputNode;
    public InputNode inputNode2;
    public Output outputNode;
    public Output outputNode2;
    public GameObject nextLevel;
    private int outputValue;
    private int testff = 0;
    public Output output;
    public GameObject redo;
    public GameObject submit;
    
    void Start()
    {
        nextLevel.SetActive(false);
        Mode.testing = false;
    }

    private void Update()
    {
       outputValue = output.GetComponent<Output>().outputValue;
    }

    public void Submit()
    {
        Mode.testing = true;
        
        // StartCoroutine(testFF(0, 0, 0, 0.0f));
        // StartCoroutine(testFF(0, 1, 0, 0.1f));
        // StartCoroutine(testFF(1, 0, 0, 0.2f));
        // StartCoroutine(testFF(1, 1, 0, 0.3f));
        // StartCoroutine(testFF(0, 0, 1, 0.4f));
        // StartCoroutine(testFF(0, 1, 1, 0.5f));
        // StartCoroutine(testFF(1, 0, 1, 0.6f));
        // StartCoroutine(testFF(1, 1, 1, 0.7f));
        // StartCoroutine(testFF(0, 0, 1, 0.8f));
        // StartCoroutine(testFF(0, 1, 1, 0.9f));
        // StartCoroutine(testFF(1, 0, 1, 1f));
        // StartCoroutine(testFF(1, 1, 1, 1.1f));
        StartCoroutine(testFF(0, 0, 0, 0, 0, 0.0f));
        StartCoroutine(testFF(0, 0, 0, 1, 0, 0.1f));
        StartCoroutine(testFF(0, 0, 1, 0, 0, 0.2f));
        StartCoroutine(testFF(0, 0, 1, 1, 0, 0.3f));
        StartCoroutine(testFF(0, 1, 0, 0, 1, 0.4f));
        StartCoroutine(testFF(0, 1, 0, 1, 1, 0.5f));
        StartCoroutine(testFF(0, 1, 1, 0, 1, 0.6f));
        StartCoroutine(testFF(0, 1, 1, 1, 1, 0.7f));
        StartCoroutine(testFF(1, 0, 0, 0, 1, 0.8f));
        StartCoroutine(testFF(1, 0, 0, 1, 1, 0.9f));
        StartCoroutine(testFF(1, 0, 1, 0, 1, 1f));
        StartCoroutine(testFF(1, 0, 1, 1, 1, 1.1f));
        Invoke("method", 1.2f);
    }
    private IEnumerator testFF(int input_1, int input_2, int input_3, int input_4, int exp_Output, float time)
    {
        yield return new WaitForSeconds(time);

        inputNode.setValue(input_3);
        inputNode2.setValue(input_4);
        outputNode.setValue(input_1);
        outputNode2.setValue(input_2);
        
        yield return new WaitForSeconds(0.01f);

        Debug.Log("Test: " + outputValue);

        if (outputValue == exp_Output)
        {
            testff++;
        }
    }

    public void NextLevel()
    {
        Mode.testing = false;
        SceneManager.LoadScene("CityOverview");
    }

    public void Redo()
    {
        redo.SetActive(false);
        Mode.testing = false;
    }

    void method() {
        Debug.Log(testff);
        if (testff == 12)
        {
            PlayerPrefs.SetFloat("Completed", (PlayerPrefs.GetFloat("Completed") + 5));
            nextLevel.SetActive(true);
            submit.SetActive(false);
        } else
        {
            testff = 0;
            redo.SetActive(true);
        }
    }
}
