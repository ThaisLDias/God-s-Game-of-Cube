using UnityEngine;
using System.Collections;

public class MusicEffect : MonoBehaviour {
	
	public static MusicEffect instanceE = null;
	public AudioSource audioSourceE;
	
	
	public static bool soundOn = true;
	

	void Awake () {
		if (instanceE == null) {
			DontDestroyOnLoad (this.gameObject);
			instanceE = this;
		} else
			Destroy (this.gameObject);
	}


	void Start()
	{
		audioSourceE = GetComponent<AudioSource> ();
		audioSourceE.Play ();
		
	}
	
	public static void PlayMusic()
	{
		if(instanceE != null) 
			instanceE.audioSourceE.Play ();
	}
	
	public static void StopMusic()
	{
		if(instanceE != null)
			instanceE.audioSourceE.Stop ();
	}
	
	public static void ToggleMusic()
	{
		soundOn = !soundOn;
		if (soundOn)
			PlayMusic ();
		else
			StopMusic ();
	}
	
}
