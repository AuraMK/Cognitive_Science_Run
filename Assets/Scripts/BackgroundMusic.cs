using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic bgMusic;

    void Awake() // called when game object is activated
    {
        if(bgMusic == null) 
        {
            bgMusic = this; // create the first instannce of the background music
            DontDestroyOnLoad(bgMusic); // continue playing musci through scene changes
        }
        else
        {
            Destroy(gameObject); // prevent duplicate instances of the background music
        }
    }
    
}
