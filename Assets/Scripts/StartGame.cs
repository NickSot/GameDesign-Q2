using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Start() 
    {
        //if (PlayerPrefs.GetFloat("", 0) == 0) 
        //{
        PlayerPrefs.SetFloat("", 0);
        //}

        PlayerPrefs.SetFloat("Completed", 0);
        PlayerPrefs.SetInt("CompletedWater1", 0);
        PlayerPrefs.SetInt("CompletedWater2", 0);
        PlayerPrefs.SetInt("CompletedLight1", 0);
        PlayerPrefs.SetInt("CompletedLight2", 0);
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
