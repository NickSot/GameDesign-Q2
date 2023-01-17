using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ANDTutorialCheck : MonoBehaviour
{
    public InputNode inputNode;
    public InputNode inputNode2;
    public GameObject nextLevel;
    private int outputValue;
    private int testAnd = 0;
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
        
        StartCoroutine(testAND(0, 0, 0, 0.0f));
        StartCoroutine(testAND(0, 1, 0, 0.1f));
        StartCoroutine(testAND(1, 0, 0, 0.2f));
        StartCoroutine(testAND(1, 1, 1, 0.3f));
        Invoke("method", 0.4f);
    }
    private IEnumerator testAND(int input_1, int input_2, int exp_Output, float time)
    {
        yield return new WaitForSeconds(time);

        inputNode.setValue(input_1);
        inputNode2.setValue(input_2);

        yield return new WaitForSeconds(0.01f);

        Debug.Log("Test: " + outputValue);

        if (outputValue == exp_Output)
        {
            testAnd++;
        }
    }

    public void NextLevel()
    {
        Mode.testing = false;
        SceneManager.LoadScene("OR_Tutorial");
    }

    public void Redo()
    {
        redo.SetActive(false);
        Mode.testing = false;
    }

    void method() {
        Debug.Log(testAnd);
        if (testAnd == 4)
        {
            congrats.SetActive(true);
            nextLevel.SetActive(true);
            submit.SetActive(false);
            PlayerPrefs.SetFloat("", 2);
        } else
        {
            testAnd = 0;
            redo.SetActive(true);
        }
    }
}
