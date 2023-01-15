using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORTutorialCheck : MonoBehaviour
{
    public InputNode inputNode;
    public InputNode inputNode2;
    public GameObject nextLevel;
    private int outputValue;
    private int testOr = 0;
    public Output output;
    public GameObject redo;
    
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
        StartCoroutine(testOR(0, 1, 1, 0.1f));
        StartCoroutine(testOR(1, 0, 1, 0.2f));
        StartCoroutine(testOR(1, 1, 1, 0.3f));
        Invoke("method", 0.4f);
    }
    private IEnumerator testOR(int input_1, int input_2, int exp_Output, float time)
    {
        yield return new WaitForSeconds(time);

        inputNode.setValue(input_1);
        inputNode2.setValue(input_2);

        yield return new WaitForSeconds(0.01f);

        Debug.Log("Test: " + outputValue);

        if (outputValue == exp_Output)
        {
            testOr++;
        }
    }

    public void NextLevel()
    {
        Mode.testing = false;
        //SceneManager.LoadScene("Map");
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
            nextLevel.SetActive(true);
        } else
        {
            testOr = 0;
            redo.SetActive(true);
        }
    }
}
