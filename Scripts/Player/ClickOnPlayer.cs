using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnPlayer : MonoBehaviour {

	public AudioSource Source;
	public AudioClip[] Clips;


	void OnMouseDown()
	{
		if (Source.clip == Clips [0] || !Source.isPlaying) {
			StartCoroutine (NextMusic (Clips[1], 25));
		}
	}
	void Start () {
		Source = GameObject.Find ("AudioPlayer").GetComponent<AudioSource> ();
	}
		
	IEnumerator NextMusic(AudioClip clip, int steps)
	{
		float volume = Source.volume;
		for (int i = 0; i < steps; i++) {
			Source.volume -= (1f/(float)steps)*volume;
			yield return new WaitForEndOfFrame ();
		}
		yield return new WaitForEndOfFrame ();
		Source.volume = volume;
		Source.clip = clip;
		Source.Play ();
		yield break;
	}

}
