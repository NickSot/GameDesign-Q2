using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WaterDistributionCheck : MonoBehaviour
{
    public InputNode inputNode;
    public InputNode inputNode2;
    public InputNode inputNode3;
    public GameObject nextLevel;
    private int outputValue;
    private int testW = 0;
    public Output output;
    public GameObject redo;
    public GameObject submit;
    public GameObject Exit;
    public GameObject congrats;

    void Start()
    {
        nextLevel.SetActive(false);
        Mode.testing = false;
        if (SceneManager.GetActiveScene().name == "WaterDistribution") 
        {
            PlayerPrefs.SetInt("Water", 1);
        } else if (SceneManager.GetActiveScene().name == "WaterDistribution 1") 
        {
            PlayerPrefs.SetInt("Water", 2);
        }
    }

    private void Update()
    {
       outputValue = output.GetComponent<Output>().outputValue;
    }

    public void Submit()
    {
        Mode.testing = true;
        
        StartCoroutine(testWater(0, 0, 0, 0, 0.0f));
        StartCoroutine(testWater(0, 0, 1, 1, 0.5f));
        StartCoroutine(testWater(0, 1, 0, 0, 1f));
        StartCoroutine(testWater(0, 1, 1, 0, 1.5f));
        StartCoroutine(testWater(1, 0, 0, 0, 2f));
        StartCoroutine(testWater(1, 0, 1, 1, 2.5f));
        StartCoroutine(testWater(1, 1, 0, 1, 3f));
        StartCoroutine(testWater(1, 1, 1, 1, 3.5f));
        
        Invoke("method", 4f);
    }
    private IEnumerator testWater(int input_1, int input_2, int input_3, int exp_Output, float time)
    {
        yield return new WaitForSeconds(time);

        inputNode.setValue(input_1);
        inputNode2.setValue(input_2);
        inputNode3.setValue(input_3);
        
        yield return new WaitForSeconds(0.05f);

        Debug.Log("Test: " + outputValue);

        if (outputValue == exp_Output)
        {
            testW++;
        }
    }

    public void NextLevel()
    {
        Mode.testing = false;
        SceneManager.LoadScene("CityOverview");
        PlayerPrefs.SetInt("Loaded", 1);
    }

    public void Redo()
    {
        redo.SetActive(false);
        Mode.testing = false;
    }

    void method() 
    {
        Debug.Log(testW);
        if (testW == 8)
        {
            congrats.SetActive(true);
            PlayerPrefs.SetFloat("Completed", (PlayerPrefs.GetFloat("Completed") + 5));
            if (PlayerPrefs.GetInt("Water") == 1) 
            {
                PlayerPrefs.SetInt("CompletedWater1", 1);
            } else if (PlayerPrefs.GetInt("Water") == 2)
            {
                PlayerPrefs.SetInt("CompletedWater2", 2);
            }
            nextLevel.SetActive(true);
            submit.SetActive(false);
            Exit.SetActive(false);
        } else
        {
            testW = 0;
            redo.SetActive(true);
        }
    }

    public void exit() 
    {
        Mode.testing = false;
        SceneManager.LoadScene("CityOverview");
        PlayerPrefs.SetInt("Loaded", 1);
    }
}
