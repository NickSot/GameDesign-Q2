using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToEnd : MonoBehaviour
{
    public void End() 
    {
        SceneManager.LoadScene("Game End");
    }
}
