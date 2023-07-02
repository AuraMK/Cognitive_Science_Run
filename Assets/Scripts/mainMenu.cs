using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level 1"); // start level 1
    }

    public void QuitGame() // if the button quit is pressed
    {
        Application.Quit(); // quit game
    }
}
