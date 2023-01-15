using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public void GameStart(){
        SceneManager.LoadScene("Game Start");
    }

    public void City(){
        
        SceneManager.LoadScene("CityOverview");
    }
    

}
