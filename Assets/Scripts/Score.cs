using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    private float score;
    public Text scoreText;
    public GameObject message1;
    public GameObject message2;
    public GameObject message3;
    public GameObject message4;
    void Start()
    {
        score = PlayerPrefs.GetFloat("");
        score += PlayerPrefs.GetFloat("Completed");
        score = ((score / 19) * 100);
        scoreText.text = "Your Grade is: " + score.ToString("F1") + "%";
        checkScore();
    }

    void checkScore() 
    {
        if (score >= 0 && score < 25) 
        {
            message1.SetActive(true);
        } else if (score >= 25 && score < 50) 
        {
            message2.SetActive(true);
        } else if (score >= 50 && score < 75) 
        {
            message3.SetActive(true);
        } else 
        {
            message4.SetActive(true);
        }
    }

    public void MainPage() 
    {
        SceneManager.LoadScene("Game Start");
    }
}
