using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int initialEnemyCount = 1;
    public GameObject[] enemies;
    private int currentEnemyCount;

    void Start()
    {
        currentEnemyCount = initialEnemyCount;
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < currentEnemyCount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5));
            Instantiate(enemies[Random.Range(0, enemies.Length)], randomPosition, Quaternion.identity);
        }
    }

    public void CheckEnemies()
    {
        currentEnemyCount--;
        if (currentEnemyCount <= 0)
        {
            currentEnemyCount *= 2; // Double the enemy count
            SpawnEnemies(); // Spawn new enemies
        }
    }
}
