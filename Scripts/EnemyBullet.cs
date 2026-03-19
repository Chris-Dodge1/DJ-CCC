using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 3f;

    public float hitXDistance = 0.8f;
    public float hitZDistance = 1.2f;

    private Vector3 moveDirection;
    private bool hasHit = false;
    private Transform player;

public void SetDirection(Vector3 direction)
{
    moveDirection = direction.normalized;

    if (moveDirection != Vector3.zero)
    {
        transform.rotation = Quaternion.LookRotation(moveDirection) * Quaternion.Euler(-90, 0, 0);
    }
}

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;

        if (hasHit || player == null) return;

        float xDiff = Mathf.Abs(transform.position.x - player.position.x);
        float zDiff = Mathf.Abs(transform.position.z - player.position.z);

        if (xDiff <= hitXDistance && zDiff <= hitZDistance)
        {
            hasHit = true;

            if (GameManager.Instance != null)
                GameManager.Instance.TakeDamage();

            if (CameraShake.Instance != null)
                CameraShake.Instance.Shake(0.2f);

            Destroy(gameObject);
        }
    }
}