using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    int deathCounter = 0;
    public TextMeshProUGUI deathCounterText;
    public void Init()
    {
        RenderDeath();
    }

    public void DyingAndCounting()
    {
        deathCounter++;
        RenderDeath();
    }

    void RenderDeath()
    {
        deathCounterText.text = "" + deathCounter;
    }

}
