using UnityEngine;
using System.Collections;

public class GoalDoor : MonoBehaviour {

	public string thisScene;
	public string[] scenes;
	private Vector3 newPos;
	public int thisLevel;
	public static GoalDoor instance;
	
	void Start()
	{
		thisLevel = Application.loadedLevel + 1;
		instance = this;
		DontDestroyOnLoad(this.gameObject);
	}
	void Update () {
		if (PlayerMovement.won) {
			newPos = new Vector3 (this.transform.position.x,
			                      2.5f,
			                      this.transform.position.z);
			transform.position = Vector3.Lerp (this.transform.position, newPos, 2f * Time.deltaTime);
			StartCoroutine(sceneDelay(2f));
		}
		Debug.Log ("<b>PlayerPrefs2:</b> " + PlayerPrefs.GetInt("level"));
	}
	
	IEnumerator sceneDelay (float _time) {
		yield return new WaitForSeconds(_time);
		
		//Debug.Log(PlayerPrefs.GetInt("level"));
		
        PlayerPrefs.SetInt("level", Application.loadedLevel + 1);
        Debug.Log ("<b>Level to load</b>" + thisLevel);
        
		//Debug.Log(PlayerPrefs.GetInt("level"));
		
		Application.LoadLevel("Score");
	}
}
