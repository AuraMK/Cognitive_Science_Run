using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private bool doublePoints;
    private bool powerupActive;
    private bool fail;
    private bool coin;
    
    private float powerupLengthCounter;

    private ScoreManager theScore;

    private Player thePlayer;
    private CameraMovement theCamera;

    private float normalPointsPSec;


    // Start is called before the first frame update
    void Start()
    {
        theScore = FindObjectOfType<ScoreManager>();
        thePlayer = FindObjectOfType<Player>();
        theCamera = FindObjectOfType<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(powerupActive) // if the powrUp is active
        {
            powerupLengthCounter -= Time.deltaTime; // keep track of time

            if(coin) // if the poweUp is a coin
            {
                theScore.ScoreAdd(10); // add 10 points to the score
            }

            if(doublePoints) // if the powerUp gives double points
            {
                theScore.pointsPerSec = normalPointsPSec * 2f; // set the points per second in the score manager to double as much
            }
            if (fail) // if the downgrade is speedUp (more likely to fail)
            {
                thePlayer.speedUp = 2f; //speed up the player
                theCamera.speedUp = 2f;// and the camera
            }

            if(powerupLengthCounter <= 0) // if the time has passed
            {
                theScore.pointsPerSec = normalPointsPSec;   //set back the points
                thePlayer.speedUp = 1f; // and the speed
                theCamera.speedUp = 1f;
                powerupActive = false; // set the powerup to not active
            }
        }        
    }

    public void ActivatePowerUps(bool points, bool failure, bool coins, float time)
    {
        coin = coins; // get the parameters and save them
        doublePoints = points; 
        fail = failure; 
        powerupLengthCounter = time;


        normalPointsPSec = theScore.pointsPerSec; 

        powerupActive = true; // set this active to achieve the change of the update function
    }
}
