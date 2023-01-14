using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        GameObject sewers = GameObject.Find("Sewers");

        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mousePos.z));

        if (Input.GetMouseButtonDown(0))
        {
            if ((mousePos.x > sewers.transform.position.x - sewers.transform.localScale.x && mousePos.x < sewers.transform.position.x + sewers.transform.localScale.x)
                && (mousePos.y > sewers.transform.position.y - sewers.transform.localScale.y && mousePos.y < sewers.transform.position.y + sewers.transform.localScale.y))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
