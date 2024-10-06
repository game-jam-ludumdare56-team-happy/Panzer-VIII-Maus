using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseSpawner : MonoBehaviour
{
    // Reference to the cheese prefab, attach cheese image to this spot on Unity's empty CheeseSpawner class
    // We are using a empty class as opposed to cheese image so many cheeses can spawn at once
    // If you only want one cheese to spawn at once you can get rid of the empty class and prob 
    // cheesePrefab and attach script to image.
    public GameObject cheesePrefab;

    // Time between cheese spawns (10 seconds)
    public float spawnInterval = 10f;

    // Timer to track spawn time
    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        //cheese immediately spawns and timer starts
        SpawnCheese();
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Reduce the timer by the time since the last frame
        spawnTimer -= Time.deltaTime;

        // If the timer reaches zero, spawn the cheese
        if (spawnTimer <= 0f)
        {
            SpawnCheese();
            // Reset the timer to the spawn interval
            spawnTimer = spawnInterval;
        }
    }

    void SpawnCheese()
    {
        // Generates Random x between said coordinates
        // I don't know what the dimensions of our game is so please change numbers to fit dimensions
        float randomXPos = Random.Range(-5f, 5f);
        // Same as above but generates random y
        float randomYPos = Random.Range(-5f, 5f);
        // Creates vector w/ coords
        Vector2 randomPosition = new Vector2(randomXPos, randomYPos);


        // Instantiate a new cheese object at the random position with 0 rotation
        Instantiate(cheesePrefab, randomPosition, Quaternion.identity);

    }
}
