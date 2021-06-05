using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
 {
    public int maxLifesAmount;
    public int currentLifesAmount;

    public void Init()
    {
        currentLifesAmount = maxLifesAmount;
    }

    public void DamagePlayer()
    {
        currentLifesAmount = Mathf.Clamp(currentLifesAmount - 1, 0, maxLifesAmount);

        if(currentLifesAmount <= 0)
        {
            //End Game
        }
    }

    public void HealPlayer()
    {
        currentLifesAmount = Mathf.Clamp(currentLifesAmount + 1, 0, maxLifesAmount);
    }
}


