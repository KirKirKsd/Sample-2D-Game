using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 10f;
    private float mx;

    public float jumpForce;
    public Transform feet;
    public LayerMask groundLayer;

    public Rigidbody2D rb;

    private void Update() {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded()) {
            Jump();
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(mx * speed, rb.velocity.y);
    }

    public void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public bool isGrounded() {
        if (Physics2D.OverlapCircle(feet.position, 0.2f, groundLayer)) {
            return true;
        }

        return false;
    }
}
