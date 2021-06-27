using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    int direction;

    public GameObject bulletPrefab;
    public Transform shootPos;
    float timer;
    public float maxTime;
    bool canShoot;

    void Start()
    {
        timer = maxTime;
        canShoot = true;
        direction = -1;
    }

    void Update()
    {
        if (canShoot)
        {
            Shoot();
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                canShoot = true;
                timer = maxTime;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet>().Shoot(direction);
        canShoot = false;
    }
}
