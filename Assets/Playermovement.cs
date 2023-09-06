using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the default movement speed.
    public float boostSpeed = 10f; // Adjust this to control the boost speed.
    private bool isGrounded = true; // Flag to track if the player is grounded.
    private bool isBoosting = false; // Flag to track if the player is currently boosting.
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get the horizontal input (left or right arrow key, or A/D keys).
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the player's movement direction.
        Vector2 movement = new Vector2(horizontalInput, 0f);

        // Apply movement speed based on whether the player is boosting, and only if grounded.
        float currentSpeed = isBoosting ? boostSpeed : moveSpeed;
        rb.velocity = new Vector2(movement.x * currentSpeed, rb.velocity.y);

        // Check for the space bar input to toggle boosting only when grounded.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isBoosting = !isBoosting;
        }
    }

    // Detect if the player is grounded using OnCollisionEnter2D and OnCollisionExit2D.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
       
        if (collision.gameObject.CompareTag("Ground"))
        {
            isBoosting = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
            
        }
    }
   
}

