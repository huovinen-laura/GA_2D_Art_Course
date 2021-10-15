using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 1f;
    public float groundCheckDistance = 0.5f;

    private SpriteRenderer sprite = null;
    private Rigidbody2D rb = null;

    private bool inAir = false;

    // Direction(?)
    private float scaleX = 1f;

    void Start()
    {
        //Set base variations
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the speed for left and right but don't mess with up and down
        rb.velocity = Vector2.right * (Input.GetAxis("Horizontal") * speed) + Vector2.up * rb.velocity.y;

        // Flip the sprite to the set direction
        if (Input.GetAxis("Horizontal") != 0)
        {
            int direction = 1;

            if (Input.GetAxis("Horizontal") < 0)
            {
                direction = -1;
            }

            transform.localScale = new Vector3(scaleX * direction, transform.localScale.y, transform.localScale.z);
        }

        // Make sure char is on the ground by checking the distance from char downwards
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance);

        // If there is ground close enough you aren't in the air
        inAir = hit.collider == null;

        // If the char is on the ground and "jump" space bar is pushed the char jumps
        if (!inAir && Input.GetButtonDown("Jump"))
        {
            transform.position += Vector3.up * 0.1f;
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
