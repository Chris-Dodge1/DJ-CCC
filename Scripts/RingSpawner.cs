using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject ringPrefab;

    [Header("Track Settings")]
    public float laneOffset = 2.5f;
    public float spawnZMin = 25f;
    public float spawnZMax = 180f;

    [Header("Ring Column Settings")]
    public int numberOfColumns = 12;
    public int ringsPerColumn = 3;
    public float zSpacingBetweenRings = 2.2f;

    [Header("Spacing Rules")]
    public float minDistanceBetweenColumns = 8f;

    private List<Vector3> usedColumnPositions = new List<Vector3>();

    void Start()
    {
        StartCoroutine(SpawnRingsAfterEnemies());
    }

    IEnumerator SpawnRingsAfterEnemies()
    {
        yield return new WaitForSeconds(0.25f);
        SpawnRingColumns();
    }

    void SpawnRingColumns()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < numberOfColumns; i++)
        {
            Vector3 columnStart = Vector3.zero;
            bool foundSpot = false;
            int attempts = 0;

            while (!foundSpot && attempts < 100)
            {
                attempts++;

                int lane = Random.Range(-1, 2);
                float x = lane * laneOffset;
                float z = Random.Range(spawnZMin, spawnZMax);

                columnStart = new Vector3(x, 1.5f, z);

                if (TooCloseToOtherColumns(columnStart))
                    continue;

                if (TooCloseToEnemies(columnStart, enemies))
                    continue;

                SpawnColumn(columnStart);
                usedColumnPositions.Add(columnStart);
                foundSpot = true;
            }
        }
    }

    void SpawnColumn(Vector3 startPos)
    {
        for (int i = 0; i < ringsPerColumn; i++)
        {
            Vector3 ringPos = new Vector3(
                startPos.x,
                startPos.y,
                startPos.z + (i * zSpacingBetweenRings)
            );

            Instantiate(ringPrefab, ringPos, Quaternion.Euler(90f, 0f, 0f));
        }
    }

    bool TooCloseToOtherColumns(Vector3 pos)
    {
        foreach (Vector3 usedPos in usedColumnPositions)
        {
            if (Vector3.Distance(pos, usedPos) < minDistanceBetweenColumns)
                return true;
        }

        return false;
    }

    bool TooCloseToEnemies(Vector3 pos, GameObject[] enemies)
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) continue;

            Vector3 enemyPos = enemy.transform.position;

            float xDiff = Mathf.Abs(pos.x - enemyPos.x);
            float zDiff = pos.z - enemyPos.z;

            bool sameLane = xDiff < 2.5f;
            bool tooCloseToEnemyViewZone = zDiff > -12f && zDiff < 24f;

            if (sameLane && tooCloseToEnemyViewZone)
                return true;
        }

        return false;
    }
}