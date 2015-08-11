using UnityEngine;
using System.Collections;

public class OnGuiScript : MonoBehaviour {

    public int movements;
    public int spawns;
    public int currentAverage;
    public int currentTime;
    private int localCounter = 0;
	private Vector3 ScreenSize;
	public GUIStyle Style;

	public Texture2D textureM;
	public Texture2D textureBack;
	public Texture2D textureEfeito;
	public Texture2D textureExit;
    void Start()
    {
        movements = 0;
        spawns = 0;
		ScreenSize.x = 100;
		ScreenSize.y = 100;
		Style.fontSize = 30;
		Style.fontStyle = FontStyle.Bold;
		Style.normal.textColor = Color.white;
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("opacityElement") == null)
        {
            movements = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().countMovement;
			PlayerPrefs.SetInt("movements",movements);
		} 
        if (GameObject.FindGameObjectWithTag("opacityElement") != null)
        {
            spawns = GameObject.Find("PlayerTime(Clone)").GetComponent<PlayerTimeMovement>().countSpawn;
			PlayerPrefs.SetInt("cubes",spawns);
		}
        currentAverage = (movements + spawns) / 2;
		Debug.Log (currentAverage);
        PlayerPrefs.SetInt("currentAverage", currentAverage);
        PlayerPrefs.SetInt("currentTime", currentTime);
        
    }

    void FixedUpdate()
    {
        localCounter++;
        currentTime = localCounter / 50;
    }

    void OnGUI() {
        GUI.Label(new Rect(20, 10, 100, 20), "Moves: " + movements.ToString());
        GUI.Label(new Rect(20, 30, 100, 20), "Cubes: " + spawns.ToString());
        GUI.Label(new Rect(20, 50, 100, 20), "Media: " + currentAverage.ToString());
        GUI.Label(new Rect(20, 70, 100, 20), "Time: " + currentTime.ToString());
        if (Time.timeScale != 1) {
			//GUI.Label(new Rect(Screen.width/4 + ScreenSize.x, Screen.height/4 + ScreenSize.y, ScreenSize.x, ScreenSize.y), "Game Paused",Style);
			GUI.Label (new Rect (290, 40, textureM.width, textureM.height), textureM);
			GUI.Label (new Rect (290, 40, textureBack.width, textureBack.height), textureBack);
			GUI.Label (new Rect (310, 40, textureEfeito.width, textureEfeito.height), textureEfeito);
			GUI.Label (new Rect (300, 40, textureExit.width, textureExit.height), textureExit);
		}
    }

}
