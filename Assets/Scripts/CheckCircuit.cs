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
    public GameObject redo;
    public GameObject submit;
    
    void Start()
    {
        bulb.GetComponent<SpriteRenderer>().color = Color.red;
        nextLevel.SetActive(false);
        Mode.testing = false;
        if (SceneManager.GetActiveScene().name == "LightBulb") 
        {
            PlayerPrefs.SetInt("Light", 1);
        } else if (SceneManager.GetActiveScene().name == "LightBulb 1") 
        {
            PlayerPrefs.SetInt("Light", 2);
        }
    }

    private void Update()
    {
       outputValue = output.GetComponent<Output>().outputValue;
    }

    public void Submit()
    {
        Mode.testing = true;
        
        StartCoroutine(TestLightBulb(0, 0, 0, 0.0f));
        StartCoroutine(TestLightBulb(0, 1, 1, 0.1f));
        StartCoroutine(TestLightBulb(1, 0, 1, 0.2f));
        StartCoroutine(TestLightBulb(1, 1, 0, 0.3f));
        Invoke("method", 0.4f);
    }
    private IEnumerator TestLightBulb(int input_1, int input_2, int exp_Output, float time)
    {
        yield return new WaitForSeconds(time);

        inputNode.setValue(input_1);
        inputNode2.setValue(input_2);

        yield return new WaitForSeconds(0.01f);

        Debug.Log("Test: " + outputValue);

        if (outputValue == exp_Output)
        {
            testLight++;
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
        Debug.Log(testLight);
        if (testLight == 4)
        {
            PlayerPrefs.SetFloat("Completed", (PlayerPrefs.GetFloat("Completed") + 3));
            if (PlayerPrefs.GetInt("Light") == 1) 
            {
                PlayerPrefs.SetInt("CompletedLight1", 1);
            } else if (PlayerPrefs.GetInt("Light") == 2)
            {
                PlayerPrefs.SetInt("CompletedLight2", 2);
            }
            bulb.GetComponent<SpriteRenderer>().color = Color.green;
            nextLevel.SetActive(true);
            submit.SetActive(false);
        } else
        {
            testLight = 0;
            redo.SetActive(true);
        }
    }
}
