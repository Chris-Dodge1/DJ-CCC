using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject enemyBulletPrefab;

    private Transform player;

    public float shootRange = 20f;
    public float laneTolerance = 0.4f;
    public float fireCooldown = 0.5f;
    public float startDelay = 1.0f;

    private float fireTimer = 0f;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
            player = playerObj.transform;

        fireTimer = startDelay;
    }

    void Update()
    {
        if (player == null || enemyBulletPrefab == null)
            return;

        fireTimer -= Time.deltaTime;

        float zDistance = transform.position.z - player.position.z;
        float xDistance = Mathf.Abs(transform.position.x - player.position.x);

        bool playerIsInFront = zDistance > 0f;
        bool playerIsCloseEnough = zDistance <= shootRange;
        bool playerIsDirectlyInLane = xDistance <= laneTolerance;

        if (playerIsInFront && playerIsCloseEnough && playerIsDirectlyInLane && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireCooldown;
        }
    }

    void Shoot()
    {
        Vector3 spawnPos = new Vector3(
            transform.position.x,
            transform.position.y + 0.5f,
            transform.position.z - 2f
        );

        GameObject bullet = Instantiate(enemyBulletPrefab, spawnPos, Quaternion.identity);

        EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();

        if (bulletScript != null)
        {
            bulletScript.SetDirection(Vector3.back);
        }
    }
}