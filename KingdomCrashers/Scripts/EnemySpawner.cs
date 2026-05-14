using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy")]
    public GameObject enemyPrefab;

    [Header("Spawn Settings")]
    public int enemyCount = 3;

    [Header("Spawn Area")]
    public float minX = -5f;
    public float maxX = 5f;
    public float spawnY = 0f;

    [Header("Spacing")]
    public float minimumDistance = 4f;

    private List<Vector3> usedPositions = new List<Vector3>();

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = GetValidPosition();

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            usedPositions.Add(spawnPosition);
        }
    }

    Vector3 GetValidPosition()
    {
        Vector3 newPosition;

        int attempts = 0;

        do
        {
            float randomX = Random.Range(minX, maxX);

            newPosition = new Vector3(
                transform.position.x + randomX,
                transform.position.y + spawnY,
                0f
            );

            attempts++;

        } while (!PositionIsValid(newPosition) && attempts < 50);

        return newPosition;
    }

    bool PositionIsValid(Vector3 position)
    {
        foreach (Vector3 usedPos in usedPositions)
        {
            if (Vector3.Distance(position, usedPos) < minimumDistance)
            {
                return false;
            }
        }

        return true;
    }
}