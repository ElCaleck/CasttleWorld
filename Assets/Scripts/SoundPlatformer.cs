using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlatformer : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _audio.Play(); 
        }
    }
}
 