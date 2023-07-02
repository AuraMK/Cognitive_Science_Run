using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerspeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public float speedUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedUp = 1; // important for powerUp

    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical"); //get the key inputs
        playerDirection = new Vector2(0, directionY).normalized; //players movement in the y coordinate and consistent 
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * (playerspeed * speedUp)); //movement in the y coordinate with the playerspeed  
    }
}
