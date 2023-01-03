using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayText : MonoBehaviour
{
    // a field to reference the TextBox and the text in our TextBox
    // we only need the textbox variable because we want to call it from other scripts
    [SerializeField] private GameObject fieldTextBox;
    [SerializeField] private TMP_Text fieldTextRef;

    // and now the actual variables
    private static GameObject textBox;
    private static TMP_Text textRef;

    // boolean to check if there is text
    public static bool Paused;
    
    // instance to get the current level
    private string currentScene;

    // for some reason after copying the code I had to format the strings like this to prevent indentation so it's ugly not
    private string lvlTutorialGreetingText = @"Welcome to the tutorial level. We are going to make an OR, a NOT and an AND Gate from NAND and NOR Gates.
   Press Enter to continue";
    // private string lvlExpText =@"bla";

    // Start is called before the first frame update
    void Start()
    {
        // set the variables;
        textBox = fieldTextBox;
        textRef = fieldTextRef;
        currentScene = SceneManager.GetActiveScene().name;
        // pause the game and display text
        PauseGame();
        // set the text to something
        if(currentScene == "Tutorial")
        {
            // display level 1 start text
            textRef.text = lvlTutorialGreetingText;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        // if the textbox is there and the player presses return while there are not multiple story textboxes
        if(Paused && Input.GetKeyDown(KeyCode.Return)) 
        {
            // stop pause
            ResumeGame();
            // disable textbox
            textBox.SetActive(false);
        }
    }

    // a static method to use everywhere to set the text
    public static void SetText(string newText)
    {
        // pause the game and display text
        PauseGame();
        // activate textbox
        textBox.SetActive(true);
        // set the text to something
        textRef.text = newText;
    }

    // a static method to pause the game from anywhere
    public static void PauseGame()
    {
        // boolean is true
        Paused = true;
        // pause time
        Time.timeScale = 0;
    }

    // a static method to resume the game from anywhere
    public static void ResumeGame()
    {
        // boolean is false
        Paused = false;
        // resume time
        Time.timeScale = 1;
    }
}
