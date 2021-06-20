using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public int maxBulletAmount; //20
    public int currentBulletAmount; //0 

    public void Recharge()
    {
        currentBulletAmount = maxBulletAmount;
            // antes 0
            //ahora 20
    }



    //Añadir 10 ballas por cada ronda 


    public void ShootBullet()
    {
        currentBulletAmount = Mathf.Clamp(currentBulletAmount - 1, 0, maxBulletAmount);
    }

    public void RechargeBullet()
    {
        currentBulletAmount = Mathf.Clamp(currentBulletAmount + 10, 0, maxBulletAmount);
    }

    public bool CanShoot()
    {
        return currentBulletAmount > 0;
    }

    public void Init()
    {
        Recharge();
        
    }
}

