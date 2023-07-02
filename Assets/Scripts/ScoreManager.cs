using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; 
    public TMP_Text highScoreText;
    public GameObject winnerPanel;
    private float score;
    public float pointsPerSec;
    [SerializeField] Animator transitionAnim;
    

    void Start()
    {
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null) // Is the player alive?
        {
            if(score > 50 && SceneManager.GetActiveScene().buildIndex != 9) // if 50 points (50%) are reached then
            {
                UnlockNewLevel(); // set the next level to unlocked
                StartCoroutine(LoadLevel()); //start the animation and next level
            }
            else if (score > 50 && SceneManager.GetActiveScene().buildIndex == 9) // if 50 points are reached and the player is in the last level
            {
                Time.timeScale = 0; // stop the game
                winnerPanel.SetActive(true); // display the winner panel
            }     
            score += pointsPerSec * Time.deltaTime; // Add a point for every second the player stays alive
            scoreText.text = "Score: " + ((int)score).ToString(); // Change Text to new value
            CheckHighScore(); 
        }
    }

    void CheckHighScore() // Is a new high score reached
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0)) // if the new score is bigger than the current highscore
        {
            PlayerPrefs.SetInt("HighScore", ((int)score)); // save new high score on personal computer/laptop
            UpdateHighScore();
        }
    }

    void UpdateHighScore() // update the old highscore text to the newly reached
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}"; // write the new highscore over the old one
    }

    public void ScoreAdd(int coin)
    {
        score += coin; // add the value of the coin to the current score
    }

    void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("Reached Index")) //if the new level is higher than the reached level
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1); // update reached level
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1); // update unlocked level
            PlayerPrefs.Save(); // save on Laptop/PC
        }
    }

    IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("End"); // start the transition 
        yield return new WaitForSeconds(1); // wait a second
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);//go to next level
        transitionAnim.SetTrigger("Start"); // start second transition
        yield return new WaitForSeconds(1); // wait a second
    }
}
