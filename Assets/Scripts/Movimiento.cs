using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rigibody;
    public int direction = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Colisionando");
            direction *= -1;
            FlipSprite();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().ResetPlayerPosition();
        }


    }




    void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        FlipSprite();
    }

     void Update()
    {
        _rigibody.velocity = new Vector2(x: direction * moveSpeed, _rigibody.velocity.y);
    }
    
    void FlipSprite()
    {
        transform.eulerAngles = new Vector3(x: 0, y: direction  == 1 ? 180 : 0, z: 0);
    }
} 
    


