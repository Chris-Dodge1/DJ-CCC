using UnityEngine;

public class PlayerRunner : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;
    public float jumpForce = 10f;
    public float gravity = -25f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private CharacterController controller;
    private Vector3 moveDirection;
    private int desiredLane = 1; // 0 = left, 1 = middle, 2 = right

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Always move forward
        moveDirection.z = forwardSpeed;

        // Lane switching
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (desiredLane > 0)
                desiredLane--;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (desiredLane < 2)
                desiredLane++;
        }

        // Jumping
        if (controller.isGrounded)
        {
            if (moveDirection.y < 0)
                moveDirection.y = -2f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

        // Shooting
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        // Lane movement
        float targetX = (desiredLane - 1) * laneDistance;
        float differenceX = targetX - transform.position.x;

        Vector3 finalMove = new Vector3(
            differenceX * laneChangeSpeed,
            moveDirection.y,
            moveDirection.z
        );

        controller.Move(finalMove * Time.deltaTime);
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}