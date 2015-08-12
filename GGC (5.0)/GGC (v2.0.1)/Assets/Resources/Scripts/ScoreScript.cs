using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
public class ScoreScript : MonoBehaviour {
 
    public Text pointsText;
	public Text optionsText;
	public Text continueText;
	public Text movesText;
	public Text timeText;
	public Text cubesText;
	public Text enterText;
	private float scoreCounter;
	private int clicks;
	public bool next;
 
    void Start () {
      	
        scoreCounter = 10000 /  PlayerPrefs.GetInt("currentAverage") ;
        pointsText = GetComponent<Text>(); 
		continueText = GetComponent<Text>(); 
		movesText = GetComponent<Text>(); 
		timeText = GetComponent<Text>(); 
		cubesText = GetComponent<Text>(); 
		optionsText = GetComponent<Text>(); 
		enterText = GetComponent<Text>(); 
		next = false;
    }
 
	    void Update () {

		if (Input.GetKeyDown (KeyCode.Return)) {
			if (clicks <= 5) 
				clicks += 1;
			if (clicks > 5 && next) {
				Application.LoadLevel (PlayerPrefs.GetInt ("level"));
			} else if (clicks > 5 && !next) {
				Application.LoadLevel ("Menu");
			}
		}

		switch(this.gameObject.name)
		{
			case "Enter":
				if(clicks  >0)
				enterText.text = "";
				break;
			case "Points":
			if(clicks >= 4)
				pointsText.text = "Points: " + scoreCounter.ToString ();
			break;
			case "Continue":
				if(clicks >= 5)
				continueText.text = "Continue? ";
				break;
			case "Time":
				if(clicks >= 1)
				timeText.text = "Time: " + PlayerPrefs.GetInt("currentTime").ToString ();
				break;
			case "Cubes":
				if(clicks >= 2)
				cubesText.text = "Cubes: " + PlayerPrefs.GetInt("cubes").ToString ();
				break;
			case "Moves":
				if(clicks >= 3)
				movesText.text = "Moves: " + PlayerPrefs.GetInt("movements").ToString ();
				break;
			case "Options":
				if(clicks >= 5)
				optionsText.text = "Yes			    	No";
				break;

		}
		if (clicks >= 5 )
		{
			if(Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.D) ) {
			next = !next;
			}
		
			if (next) {
				GameObject.FindGameObjectWithTag ("Player").
					GetComponent<PlayerMovement> ().
					transform.position = 
					new Vector3 (-3.4f,-3.4f,4f);
			}
			else{
				GameObject.FindGameObjectWithTag ("Player").
					GetComponent<PlayerMovement> ().
						transform.position = 
						new Vector3 (-3.4f,-3.4f,-1f);
			}
		}
		}
}
