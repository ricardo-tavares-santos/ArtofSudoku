using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class RandomSFX : MonoBehaviour {

	public AudioClip[] sfx;
	public AudioSource sfxSource;
	public static RandomSFX intance;
	

    void Awake()
    {
        intance = this;
    }
	
	void Update()
	{
		if (!GameManager.IsSound || GameManager.IsGamePause) {
			sfxSource.GetComponent<AudioSource>().mute = true;
		} else {
			sfxSource.GetComponent<AudioSource>().mute = false;
		}	
	}

	public void playSFX() 
	{
		if (GameManager.IsSound) {
			int randClip = Random.Range (0, sfx.Length);
			sfxSource.clip = sfx[randClip];
			sfxSource.Play();
		}
	}

}