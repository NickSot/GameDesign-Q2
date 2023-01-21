using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ORTutorialCheck : MonoBehaviour
{
    public InputNode inputNode;
    public InputNode inputNode2;
    public GameObject nextLevel;
    private int outputValue;
    private int testOr = 0;
    public Output output;
    public GameObject redo;
    public GameObject submit;
    public GameObject congrats;

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
        
        StartCoroutine(testOR(0, 0, 0, 0.0f));
        StartCoroutine(testOR(0, 1, 1, 0.5f));
        StartCoroutine(testOR(1, 0, 1, 1f));
        StartCoroutine(testOR(1, 1, 1, 1.5f));
        Invoke("method", 2f);
    }
    private IEnumerator testOR(int input_1, int input_2, int exp_Output, float time)
    {
        yield return new WaitForSeconds(time);

        inputNode.setValue(input_1);
        inputNode2.setValue(input_2);

        yield return new WaitForSeconds(0.05f);

        Debug.Log("Test: " + outputValue);

        if (outputValue == exp_Output)
        {
            testOr++;
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
        Debug.Log(testOr);
        if (testOr == 4)
        {
            congrats.SetActive(true);
            nextLevel.SetActive(true);
            submit.SetActive(false);
            PlayerPrefs.SetFloat("", 3);
        } else
        {
            testOr = 0;
            redo.SetActive(true);
        }
    }
}
