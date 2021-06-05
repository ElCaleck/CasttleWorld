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
    }
}
