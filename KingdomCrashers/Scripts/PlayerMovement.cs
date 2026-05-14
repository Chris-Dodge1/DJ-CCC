using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 12f;

    [Header("Attack Settings")]
    public GameObject attackHitbox;
    public float attackHitboxDelay = 0.15f;
    public float attackHitboxActiveTime = 0.1f;
    public float attackCooldown = 0.4f;

    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput;
    private Vector3 originalScale;
    private bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        originalScale = transform.localScale;

        if (attackHitbox != null)
            attackHitbox.SetActive(false);
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (anim != null)
            anim.SetFloat("Speed", Mathf.Abs(moveInput));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.J) && !isAttacking)
        {
            StartCoroutine(Attack());
        }

        if (moveInput > 0)
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        if (anim != null)
            anim.SetTrigger("Attack");

        yield return new WaitForSeconds(attackHitboxDelay);

        if (attackHitbox != null)
            attackHitbox.SetActive(true);

        yield return new WaitForSeconds(attackHitboxActiveTime);

        if (attackHitbox != null)
            attackHitbox.SetActive(false);

        yield return new WaitForSeconds(attackCooldown);

        isAttacking = false;
    }
}