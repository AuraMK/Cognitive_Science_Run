using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // access the object player

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Border") // if the obstacle collides with the border
        {
            Destroy(this.gameObject); // destroy the obstacle   
        }
        else if (collision.tag == "Player") // if the obstacle collides with the player
        {
            Destroy(player.gameObject); //destroy the player
        }     
    }
}
