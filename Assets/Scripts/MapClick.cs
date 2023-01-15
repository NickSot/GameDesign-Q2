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

    // function that compares the positions of the mouse and the level placeholders
    void LoadLevel(Vector3 mousePos, GameObject level, string levelName)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if ((mousePos.x > level.transform.position.x - level.transform.localScale.x && mousePos.x < level.transform.position.x + level.transform.localScale.x)
                && (mousePos.y > level.transform.position.y - level.transform.localScale.y && mousePos.y < level.transform.position.y + level.transform.localScale.y))
            {
                SceneManager.LoadScene(levelName);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // initialize the mouse position and the level placeholder positions
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject sewers = GameObject.Find("Sewers");
        GameObject lights = GameObject.Find("LightFix");
        GameObject factory = GameObject.Find("Factory");

        // Load the levels, based on the position of the mouse on the map
        // TODO: Change the names of the scenes according to their purposes
        LoadLevel(mousePos, sewers, "SampleScene");
        LoadLevel(mousePos, lights, "SampleScene");
        LoadLevel(mousePos, factory, "SampleScene");
    }
}