using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D _Rigidbody2D;
    public float bulletspeed;

    void OnEnable()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    public void Shoot (int direction)
    {
        _Rigidbody2D.velocity =  Vector2.right * direction * bulletspeed;
        FlipSprite(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || (collision.CompareTag("Ground")) )
        {
        Destroy(gameObject);
        }
    } 

    void FlipSprite(int direction)
    {
        //By rotations
        transform.eulerAngles = new Vector3(0, direction == 1 ? 0 : 180, 0);
    }
}
