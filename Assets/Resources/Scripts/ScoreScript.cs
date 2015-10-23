using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
public class ScoreScript : MonoBehaviour {
 
    public Text pointsText;
	public Text deathsText;
	public Text movesText;
	public Text timeText;
	public Text cubesText;
    float scoreCounter;
    int scoreViewer;
 
    void Start () {
      	
        scoreCounter = 10000 /  PlayerPrefs.GetInt("currentAverage") ;
        pointsText = GetComponent<Text>(); 
		deathsText = GetComponent<Text>(); 
		movesText = GetComponent<Text>(); 
		timeText = GetComponent<Text>(); 
		cubesText = GetComponent<Text>(); 

    }
 
	    void Update () {
		switch(this.gameObject.name)
		{
			case "Points":
				pointsText.text = "Points: " + scoreCounter.ToString ();
			break;
			/*case "Deaths":
				deathsText.text = PlayerPrefs.GetInt().ToString ();
				break;*/
			case "Time":
				timeText.text = "Time: " + PlayerPrefs.GetInt("currentTime").ToString ();
				break;
			case "Cubes":
				cubesText.text = "Cubes: " + PlayerPrefs.GetInt("cubes").ToString ();
				break;
			case "Moves":
				movesText.text = "Moves: " + PlayerPrefs.GetInt("movements").ToString ();
				break;

		}
		StartCoroutine(sceneDelay(10f));
	}
		IEnumerator sceneDelay (float _time) {
			yield return new WaitForSeconds(_time);
			Application.LoadLevel(PlayerPrefs.GetInt("level"));
		}
}