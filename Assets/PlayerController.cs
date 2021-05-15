using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float moveSpeed;
    public float jumpForce;
    public Vector2 input;

    //
    public Transform groundCheckPoint;
    public float radius;
    public LayerMask whatlsGround;
    private bool isGrounded = false;

    void groundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, radius, whatlsGround);
    }

    void Jump()
    {
        if (isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        }
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Moverse
        input = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, _rigidbody.velocity.y);
        _rigidbody.velocity = input;

        groundCheck();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        


        
    }
}
