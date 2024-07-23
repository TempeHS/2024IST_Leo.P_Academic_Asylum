using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f; 
    private bool isFacingRight = true;

    [Header("Wall Jump System")]
    public Transform wallCheck;
    bool isWallTouch;
    bool isSliding;
    public float wallSlidingSpeed;


    [SerializeField] private Rigidbody2D rb; 
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(1.7f, 0.24f), 0, groundLayer);
        isWallTouch= Physics2D.OverlapBox(wallCheck.position, new Vector2(.13f, 1.04f), 0, groundLayer);

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip() 
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) 
        {
            isFacingRight = !isFacingRight; 
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
