using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 60f;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(10);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}