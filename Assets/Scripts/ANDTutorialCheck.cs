using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANDTutorialCheck : MonoBehaviour
{
    public InputNode inputNode;
    public InputNode inputNode2;
    public GameObject nextLevel;
    private int outputValue;
    private int testAnd = 0;
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
        //SceneManager.LoadScene("Map");
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
            nextLevel.SetActive(true);
        } else
        {
            testAnd = 0;
            redo.SetActive(true);
        }
    }
}
