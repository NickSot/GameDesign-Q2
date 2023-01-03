using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update

    public void GameStart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex  +1);
    }

    public void Tutorial(){
        SceneManager.LoadScene("Tutorial");
    }

    public void ExitGame(){
        Application.Quit();
        Debug.Log("Exit");
    }

}
