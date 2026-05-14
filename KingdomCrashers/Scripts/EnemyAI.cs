using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    public Transform player;
    public float moveSpeed = 6f;

    [Header("Detection")]
    public float detectionRange = 25f;
    public float attackRange = 2.2f;

    [Header("Attack")]
    public int damage = 10;
    public float attackCooldown = 0.8f;
    public float attackDelay = 0.35f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private bool isAttacking;
    private bool isStunned;
    private float lastAttackTime;

    private Coroutine attackCoroutine;
    private Coroutine stunCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        FindPlayer();
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            FindPlayer();
            return;
        }

        if (isStunned)
        {
            StopMoving();
            return;
        }

        FacePlayer();

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > detectionRange)
        {
            StopMoving();
            return;
        }

        if (distanceToPlayer <= attackRange)
        {
            StopMoving();

            if (!isAttacking && Time.time >= lastAttackTime + attackCooldown)
            {
                attackCoroutine = StartCoroutine(AttackRoutine());
            }

            return;
        }

        if (!isAttacking)
        {
            MoveTowardsPlayer();
        }
    }

    void FindPlayer()
    {
        GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");

        if (foundPlayer != null)
        {
            player = foundPlayer.transform;
        }
    }

    void MoveTowardsPlayer()
    {
        float direction = Mathf.Sign(player.position.x - transform.position.x);

        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

        if (anim != null)
            anim.SetBool("isRunning", true);
    }

    void StopMoving()
    {
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);

        if (anim != null)
            anim.SetBool("isRunning", false);
    }

    void FacePlayer()
    {
        if (spriteRenderer == null || player == null) return;

        spriteRenderer.flipX = player.position.x < transform.position.x;
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;
        lastAttackTime = Time.time;

        StopMoving();
        FacePlayer();

        if (anim != null)
            anim.SetTrigger("Attack");

        yield return new WaitForSeconds(attackDelay);

        if (!isStunned && player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange + 0.4f)
            {
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                    Debug.Log("Enemy hit player for " + damage);
                }
            }
        }

        yield return new WaitForSeconds(0.2f);

        isAttacking = false;
        attackCoroutine = null;
    }

    public void StunEnemy(float stunTime)
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            attackCoroutine = null;
        }

        isAttacking = false;
        isStunned = true;

        StopMoving();

        if (stunCoroutine != null)
            StopCoroutine(stunCoroutine);

        stunCoroutine = StartCoroutine(StunRoutine(stunTime));
    }

    IEnumerator StunRoutine(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);

        isStunned = false;
        stunCoroutine = null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}