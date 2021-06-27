using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    //Para asignar la velocidad de la bala
    public float bulletSpeed;
    public float deathTime;


    void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, deathTime);
    }

    public void Shoot(int _direction)
    {
        _rigidbody.velocity = Vector2.right * _direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            //Destruye la bala
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().ResetPlayerPosition();
            //Destruye la bala
            Destroy(this.gameObject);
        }
    }
}
