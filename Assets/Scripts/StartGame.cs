using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Start() 
    {
        if (PlayerPrefs.GetFloat("", 0) == 0) 
        {
            PlayerPrefs.SetFloat("", 0);
        }

        PlayerPrefs.SetFloat("Completed", 0);
    }

    public void GameStart(){
        SceneManager.LoadScene("CityOverview");
    }

    public void Tutorial(){
        SceneManager.LoadScene("NOT_Tutorial");
    }

    public void ExitGame(){
        Application.Quit();
        Debug.Log("Exit");
    }

}
