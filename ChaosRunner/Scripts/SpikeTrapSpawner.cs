using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject spikeTrapPrefab;

    [Header("Track Settings")]
    public float laneOffset = 2.5f;
    public float spawnZMin = 30f;
    public float spawnZMax = 180f;

    [Header("Trap Settings")]
    public int numberOfTraps = 8;
    public float trapYPosition = 0f;

    [Header("Spacing Rules")]
    public float minDistanceBetweenTraps = 10f;
    public float minDistanceFromRings = 4f;
    public float minDistanceFromEnemiesZ = 1.5f;

    private List<Vector3> usedTrapPositions = new List<Vector3>();

    void Start()
    {
        StartCoroutine(SpawnTrapsAfterLevelObjects());
    }

    IEnumerator SpawnTrapsAfterLevelObjects()
    {
        yield return new WaitForSeconds(0.4f);
        SpawnTraps();
    }

    void SpawnTraps()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] rings = GameObject.FindGameObjectsWithTag("Ring");

        for (int i = 0; i < numberOfTraps; i++)
        {
            Vector3 trapPos = Vector3.zero;
            bool foundSpot = false;
            int attempts = 0;

            while (!foundSpot && attempts < 100)
            {
                attempts++;

                int lane = Random.Range(-1, 2); // -1, 0, 1
                float x = lane * laneOffset;
                float z = Random.Range(spawnZMin, spawnZMax);

                trapPos = new Vector3(x, trapYPosition, z);

                if (TooCloseToOtherTraps(trapPos))
                    continue;

                if (TooCloseToRings(trapPos, rings))
                    continue;

                if (TooCloseToEnemies(trapPos, enemies))
                    continue;

                Instantiate(spikeTrapPrefab, trapPos, Quaternion.identity);
                usedTrapPositions.Add(trapPos);
                foundSpot = true;
            }
        }
    }

    bool TooCloseToOtherTraps(Vector3 pos)
    {
        foreach (Vector3 usedPos in usedTrapPositions)
        {
            if (Vector3.Distance(pos, usedPos) < minDistanceBetweenTraps)
                return true;
        }

        return false;
    }

    bool TooCloseToRings(Vector3 pos, GameObject[] rings)
    {
        foreach (GameObject ring in rings)
        {
            if (ring == null) continue;

            Vector3 ringPos = ring.transform.position;

            float xDiff = Mathf.Abs(pos.x - ringPos.x);
            float zDiff = Mathf.Abs(pos.z - ringPos.z);

            bool sameLane = xDiff < 1.2f;
            bool tooClose = zDiff < minDistanceFromRings;

            if (sameLane && tooClose)
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
            float zDiff = Mathf.Abs(pos.z - enemyPos.z);

            bool sameLane = xDiff < 1.2f;
            bool tooCloseAheadOrBehind = zDiff < minDistanceFromEnemiesZ;

            if (sameLane && tooCloseAheadOrBehind)
                return true;
        }

        return false;
    }
}
