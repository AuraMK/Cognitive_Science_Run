using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null) // if the player died
        {
            gameOverPanel.SetActive(true); // activate the game over panel
        }
    }

    public void Restart() // button pressed restart
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload the active level
    }
}
