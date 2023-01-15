using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject gameObject;  
    bool isActive; 


    public void PanelOpener() {  
       
       if (isActive == false)
       {
        gameObject.transform.gameObject.SetActive(true);
        isActive = true;
       }
       else
       {
        gameObject.transform.gameObject.SetActive(false);
        isActive = false;
       }
    }  


    public void GameStart(){
        SceneManager.LoadScene("Game Start");
    }

    public void Tutorial2(){
        
        SceneManager.LoadScene("Tutorial2");
    }

    public void Tutorial3(){
        
        SceneManager.LoadScene("Tutorial3");
    }

    

}
