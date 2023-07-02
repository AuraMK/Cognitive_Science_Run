using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour //distribute obstacles and powerUps randomly
{
    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;

    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime) // if the time passed is bigger than the time we pick between 2 spawns
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn; // update time so that the distance is correct
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Obstacle") // if the spawn is create on or too close to an obstacle
        {
            Destroy(this.gameObject); //then destroy it 
            Spawn(); // and recreate it
        }
        else if (collision.tag == "powerUp") // same as upper part, just for powerUps
        {
            Destroy(this.gameObject);
            Spawn();
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX); 
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation); // create the object at a random point using the parameters created above
    }
}
