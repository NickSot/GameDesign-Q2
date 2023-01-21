using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NotTutorialCheck : MonoBehaviour
{
    public InputNode inputNode;
    public GameObject nextLevel;
    public GameObject submit;
    private int outputValue;
    private int testNot = 0;
    public Output output;
    public GameObject redo;
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
        
        StartCoroutine(TestNot(0, 1, 0f));
        StartCoroutine(TestNot(1, 0, 0.5f));
        Invoke("method", 1f);
    }
    private IEnumerator TestNot(int input_1, int exp_Output, float time)
    {
        yield return new WaitForSeconds(time);

        inputNode.setValue(input_1);

        yield return new WaitForSeconds(0.05f);

        Debug.Log("Test: " + outputValue);

        if (outputValue == exp_Output)
        {
            testNot++;
        }
    }

    public void NextLevel()
    {
        Mode.testing = false;
        SceneManager.LoadScene("AND_Tutorial");
    }

    public void Redo()
    {
        redo.SetActive(false);
        Mode.testing = false;
    }

    void method() {
        Debug.Log(testNot);
        if (testNot == 2)
        {
            congrats.SetActive(true);
            nextLevel.SetActive(true);
            submit.SetActive(false);
            PlayerPrefs.SetFloat("", 1);
        } else
        {
            testNot = 0;
            redo.SetActive(true);
            PlayerPrefs.SetFloat("", 0);
        }
    }
}
