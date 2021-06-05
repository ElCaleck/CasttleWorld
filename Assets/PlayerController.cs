using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float moveSpeed;
    public float jumpForce;
    public Vector2 input;
    int direction = 1;

    //
    public Transform groundCheckPoint;
    public float radius;
    public LayerMask whatlsGround;
    private bool isGrounded = false;

    //
    private Vector3 resetPos;
    bool canDoubleJump = true;
    public PlayerHealth _PlayerHealth;

    //shoting

    public GameObject bullet; // Aqui se añade el prefab que se clona al disparar 
    public Transform shootPos;

    void FlipSprite()
    {
        //By rotations
        transform.eulerAngles = new Vector3(0, direction == 1 ? 0 : 180, 0);
    }


    void groundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, radius, whatlsGround);
        if (isGrounded) { canDoubleJump = true; }
    }

    void Jump()
    {
        if (isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        }
        else if (canDoubleJump) { _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            canDoubleJump = false;
        }
    }

    void ShootBullet()
    {
        Instantiate(bullet, shootPos.position, Quaternion.identity);
    }
    
    




    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        resetPos = transform.position;

        _PlayerHealth = GetComponent<PlayerHealth>();
    }
     

    void Update()
    {
        //Moverse
        input = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, _rigidbody.velocity.y);
        //Derecha 
        if (input.x > 0) {
            direction = 1;


        }
        else if (input.x < 0)
        {
            direction = -1;
        }
        FlipSprite();





        _rigidbody.velocity = input;

        groundCheck();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if(Input.GetButton("Firel" ))
        {
            ShootBullet();
        }
    }

    public void ResetPlayerPosition()
    {
        transform.position = resetPos;
    }
}
