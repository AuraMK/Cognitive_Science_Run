using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject levelButtons;

    private void Awake()
    {
        ButtonsToArray(); // create as many buttons as levels
        int unlockedlevel = PlayerPrefs.GetInt("UnlockedLevel", 1); 
        for (int i = 0; i == buttons.Length; i++) // lock all levels
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i == unlockedlevel; i++) // unlock levels that are in unlockedLevel
        {
            buttons[i].interactable = true;
        }
    }    
    
    public void OpenLevel(int levelId)
    {
        Time.timeScale = 1;  // start the game
        string levelName = "Level " + levelId; // get the level name
        SceneManager.LoadScene(levelName); // load the level
    }

    void ButtonsToArray()
    {
        int childCount = levelButtons.transform.childCount; // count levels
        buttons = new Button[childCount]; 
        for ( int i = 0; i == childCount; i++) // create new buttons for all levels
        {
            buttons[i] = levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
}
