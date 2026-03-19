using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform finishLine;

    public float startZ = 25f;
    public float spawnDistance = 15f;
    public float endBuffer = 20f;

    private float[] lanePositions = { -3f, 0f, 3f };

    void Start()
    {
        if (enemyPrefab == null || finishLine == null)
        {
            Debug.LogWarning("EnemySpawner is missing references.");
            return;
        }

        float currentZ = startZ;
        float maxZ = finishLine.position.z - endBuffer;

        while (currentZ < maxZ)
        {
            int randomLane = Random.Range(0, lanePositions.Length);

            Vector3 spawnPos = new Vector3(
                lanePositions[randomLane],
                1.5f,
                currentZ
            );

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            currentZ += spawnDistance;
        }
    }
}