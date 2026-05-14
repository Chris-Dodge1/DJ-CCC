using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public int damage = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Real enemies that can die
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            return;
        }

        // Practice dummies that do not die
        EnemyDamage dummy = other.GetComponent<EnemyDamage>();
        if (dummy != null)
        {
            dummy.TakeDamage(damage);
        }
    }
}