using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject mouse;
    [SerializeField] private GameObject enemy;

    public float frequency = 0.5f;
    public float timeUntilSpawn;
    public int totalEnemies = 10;
    Vector2 resolution = new Vector2(50, 50);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0)
        {
            SpawnEnemies();
            SetSpawnRate();
        }
    }

    void Awake() {
        SetSpawnRate();
    }

    private void SetSpawnRate()
    {
        float waitTime = Random.Range(0, frequency);
        timeUntilSpawn = waitTime;
    }

    private void SpawnEnemies() 
    {
        GameObject enemyClone = Instantiate(enemy, SetStartLocation(), Quaternion.identity);
    }

    private Vector3 SetStartLocation()
    {
        int spawnSide = Random.Range(0, 4); // Randomly choose a side
        Vector2 mousePosition = mouse.transform.position;
        switch (spawnSide)
        {
            case 0: // Bottom
                return new Vector3(
                    Random.Range(mousePosition.x - resolution.x / 2, mousePosition.x + resolution.x / 2),
                    mousePosition.y - resolution.y / 2
                );
            case 1: // Top
                return new Vector3(
                    Random.Range(mousePosition.x - resolution.x / 2, mousePosition.x + resolution.x / 2),
                    mousePosition.y + resolution.y / 2
                );
            case 2: // Left
                return new Vector3(
                    mousePosition.x - resolution.x / 2,
                    Random.Range(mousePosition.y - resolution.y / 2, mousePosition.y + resolution.y / 2)
                );
            case 3: // Right
                return new Vector3(
                    mousePosition.x + resolution.x / 2,
                    Random.Range(mousePosition.y - resolution.y / 2, mousePosition.y + resolution.y / 2)
                );
        }
        return new Vector3(-15, 0, 0);
    }
}
