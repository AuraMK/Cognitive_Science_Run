using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public bool doublePoints;
    public bool failure;
    public bool coin;
    public float powerupLength;

    private PowerupManager theManager;
    
    // Start is called before the first frame update
    void Start()
    {
        theManager = FindObjectOfType<PowerupManager>(); // access the PowerUp Manager
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player") // if player reaches the powerUp (also includes downgrades)
        {
            theManager.ActivatePowerUps(doublePoints, failure, coin, powerupLength); // give the parameters of the powerUp to the function of the manager
        }
        gameObject.SetActive(false); // this object does not activate anymore after being hit once.
    }
}
