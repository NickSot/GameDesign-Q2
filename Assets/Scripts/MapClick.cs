using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapClick : MonoBehaviour
{
    GameObject sewers;
    GameObject lights;
    GameObject secondLights;
    GameObject factory;
    // Start is called before the first frame update
    void Awake()
    {
        sewers = GameObject.Find("Sewers");
        lights = GameObject.Find("LightFix");
        factory = GameObject.Find("Factory");
        secondLights = GameObject.Find("LightFix 2");
    }

    // function that compares the positions of the mouse and the level placeholders
    void LoadLevel(Vector3 mousePos, GameObject level, int levelName)
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(mousePos);
            Debug.Log(level.transform.position);

            if ((mousePos.x > level.transform.position.x - level.transform.localScale.x && mousePos.x < level.transform.position.x + level.transform.localScale.x)
                && (mousePos.y > level.transform.position.y - level.transform.localScale.y && mousePos.y < level.transform.position.y + level.transform.localScale.y))
            {
                Debug.Log(levelName);
                SceneManager.LoadScene(levelName);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // initialize the mouse position and the level placeholder positions
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // GameObject sewers = GameObject.Find("Sewers");
        // GameObject lights = GameObject.Find("LightFix");
        // GameObject factory = GameObject.Find("Factory");

        // Load the levels, based on the position of the mouse on the map
        // TODO: Change the names of the scenes according to their purposes
        LoadLevel(mousePos, sewers, 7);
        LoadLevel(mousePos, lights, 7);
        LoadLevel(mousePos, factory, 6);
        LoadLevel(mousePos, secondLights, 7);
    }
}
