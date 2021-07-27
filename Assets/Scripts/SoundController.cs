using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
	public static SoundController _instance;

	public AudioSource shoot;
	public AudioSource death;
	public AudioSource jump;
	public AudioSource enemy;

	void Awake()
	{
		if (_instance == null)
			_instance = this;
		else
			Destroy(this.gameObject);
	}

	public void PlayShoot()
	{
		shoot.Play();
	}

	public void PlayDeath()
	{
		death.Play();
	}

	public void PlayJump()
	{
		jump.Play();
	}

}
