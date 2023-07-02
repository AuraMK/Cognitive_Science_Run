using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    
    public void Pause() // button pressed pause
    {
        pauseMenu.SetActive(true); 
        Time.timeScale = 0; //stop the game
    }

    public void Home() // button presssed home
    {
        SceneManager.LoadScene("Main Menu"); //load the start page
        Time.timeScale = 1;  // start the game
    }

    public void Resume() // button pressed resume
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1; // continue the game
    }
    
    public void Restart() // button pressed restart
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart the level
        Time.timeScale = 1; //start the game
    }
}
