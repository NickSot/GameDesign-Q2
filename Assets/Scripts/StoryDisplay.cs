using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryDisplay : MonoBehaviour
{
    public Text story;
    float pause = 0.09f;
    string sentence = "Save our Community, follows the story of the player who tries to help their post-apocalyptic civilization with their vital clear water sourcing problem. In order to face this problem the player finds a pre-apocalypse educational robot designed and built by Eindhoven University of Technology named RoboTUe. With RobotTUe, the player learns logical circuitry which is taught in Eindhoven University of Technology in course Computer Systems (2IC30). By obtaining relevant knowledge from RoboTUe the player fixes the sewage systems of their civilization to fix their clean water problem. The main conflict in the game revolves around the player against the nature. The player faces their nature as in the post-apocalyptic future vital infrastructures are damaged. \n \nThe Game is set in a post-apocalyptic civilization where modern infrastructure has collapsed and the society is in critical condition where there lack to satisfy their basic needs. Vegetation is thick and invasive but unfruitful, it isn't suitable for agriculture. RoboTUe will provide the player with relevant information to successfully solve each level.";
    private AudioSource src;
    void Start()
    {
        StartCoroutine(TypeSentence(sentence));
        src = GetComponent<AudioSource>();
        src.Play();
    }

    private IEnumerator TypeSentence(string sentence) 
    {
        string[] array = sentence.Split(' ');
        story.text = array[0]; 
        for( int i = 1 ; i < array.Length ; ++ i)
        { 
          yield return new WaitForSeconds(pause);
          story.text += " " + array[i]; 
        }
    }

    public void playGame() 
    {
        SceneManager.LoadScene("Game Start");
    }
}
