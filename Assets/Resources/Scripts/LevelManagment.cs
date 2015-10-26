using UnityEngine;
using System.Collections;

public class LevelManagment : MonoBehaviour {

	public AudioClip source;

	void Awake() {
		DontDestroyOnLoad (this.gameObject);
		PlayerPrefs.DeleteAll();
	}

	public void levelManager (string level) {
		audio.clip = source;
		audio.loop = false;
		audio.Play ();
		Application.LoadLevel (level);
	}
}
