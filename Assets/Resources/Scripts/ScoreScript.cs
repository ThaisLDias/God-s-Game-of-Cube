using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
public class ScoreScript : MonoBehaviour {
 
    public Text pointsText;
	public Text movesText;
	public Text timeText;
	public Text cubesText;
	private float scoreCounter;
	private int count;
	private int clicks;
	public int[] values = new int[4];
	
	
    void Start () {
		values[0] = OnGuiScript.instance.currentTime;
		values[1] = OnGuiScript.instance.currentAverage;
		values[2] = OnGuiScript.instance.movements;
		values[3] = OnGuiScript.instance.spawns;
		Destroy(OnGuiScript.instance);
      	clicks = 0;
		if(PlayerPrefs.GetInt("currentAverage") > 0)
		{
        	scoreCounter = 10000 /  PlayerPrefs.GetInt("currentAverage");
        }
        pointsText = GetComponent<Text>(); 
		movesText = GetComponent<Text>();
		timeText = GetComponent<Text>(); 
		cubesText = GetComponent<Text>();
    }
	
	
	void FixedUpdate()
	{
		count++;
		if(count > 60)
		{
			count = 0;
			
			clicks +=1;
		}
		
		switch(this.gameObject.name) 
		{	
			case "Points":
					if(clicks >= 3)
						pointsText.text = "Points: " + values[1].ToString();
					break;
				case "Time":
					if(clicks >= 1)
						timeText.text = "Time: " + values[0].ToString();
					break;
				case "Cubes":
					if(clicks >= 2)
						cubesText.text = "Cubes: " + values[3].ToString();
					break;
				case "Moves":
					if(clicks >= 4)
					movesText.text = "Moves: " + values[2].ToString();
					break;
		}
		
		if (clicks >= 5) 
		{
			
			Application.LoadLevel(GoalDoor.instance.thisLevel);
		}
	}
}
