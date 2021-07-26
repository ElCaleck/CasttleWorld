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

    //Animation

    public Animator animator;

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
    float timer = 0;
    public float maxTimeBetweenBullets;
    bool canShoot = true;

    // 
    BulletManager BulletManager;
    DeathCounter deathCounter;
    
    void FlipSprite()
    {
        //By rotations
        transform.eulerAngles = new Vector3(0, direction == 1 ? 0 : 180, 0);
    }


    void groundCheck()
    {
        if (isGrounded)
        {
              canDoubleJump = true;
              animator.SetBool("isGrounded", true);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, radius, whatlsGround);
        if (isGrounded) { canDoubleJump = true; }

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, radius, whatlsGround); 
        
    }

    void Jump()
    {
        if (isGrounded)
        {
            SoundController._instance.PlayJump(); 

            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        }
        else if (canDoubleJump) 
        {
            SoundController._instance.PlayJump();

            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            canDoubleJump = false;
        }
    }

    void ShootBullet()
    {
        SoundController._instance.PlayShoot();

        GameObject tempBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        tempBullet.GetComponent<Bullet>().Shoot(direction);

        canShoot = false;

        BulletManager.ShootBullet();
    }
    
    




    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        resetPos = transform.position;

        _PlayerHealth = GetComponent<PlayerHealth>();

        direction = 1;

        timer = maxTimeBetweenBullets;

        BulletManager = GetComponent<BulletManager>();
        BulletManager.Init();

        deathCounter = GetComponent<DeathCounter>();
        deathCounter.Init();

        animator = GetComponent<Animator>();

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

       

        if (canShoot)
        {
            if (Input.GetButton("Fire1"))
            {
                if(BulletManager.CanShoot())
                ShootBullet();
            }
        }

        ShootTimer();
    }

    public void ResetPlayerPosition()
    {
        SoundController._instance.PlayDeath();

        transform.position = resetPos;
        deathCounter.DyingAndCounting();
    }

    void ShootTimer()
    {
        //Si no puedo disparar
        if (!canShoot)
        {

            //Entonces corre un cooldown
            timer -= Time.deltaTime;

            //Cuando el cooldown termine, entonces puedo volver a disparar
            if (timer <= 0)
            {
                timer = maxTimeBetweenBullets;
                canShoot = true;
            }
        }
    }
}
