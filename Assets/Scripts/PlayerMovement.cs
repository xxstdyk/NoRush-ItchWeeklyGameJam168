using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 100f;

    [SerializeField]
    private float jumpVelocity = 100f;

    [SerializeField]
    private float moveSpeedSmoothTime = 0.5f;

    private float leftRight = 0;
    private bool isOnGround = true, jumping = false;

    private Rigidbody2D rb;
    private Vector2 m_velocity = Vector2.zero;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        leftRight = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (isOnGround && !jumping)
                jumping = true;
        }
    }

    void FixedUpdate()
    {

        if (!Mathf.Approximately(leftRight, 0f))
            leftRight = leftRight < 0f ? -1f : 1f;

        Vector2 targetVelocity = new Vector2(leftRight * moveSpeed * Time.deltaTime, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref m_velocity, moveSpeedSmoothTime);

        if (jumping)
        {

            jumping = false;
            isOnGround = false;

            rb.AddForce(new Vector2(0, 1) * jumpVelocity);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Ground")
            isOnGround = true;
    }
}