using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioClip powerup;
    public AudioClip explosion;

    private AudioSource audio;
	// Use this for initialization
	void Start () {

        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayPowerUp()
    {
        audio.clip = powerup;
        audio.pitch = 1f;
        audio.Play();
    }

    public void PlayBadPowerUp()
    {
        audio.clip = powerup;
        audio.pitch = 1f;
        audio.Play();
    }

    public void PlayExplosion()
    {
        audio.clip = explosion;
        audio.pitch = 1f;
        audio.Play();
    }

}
