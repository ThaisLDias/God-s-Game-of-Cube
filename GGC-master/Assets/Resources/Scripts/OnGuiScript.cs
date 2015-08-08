using UnityEngine;
using System.Collections;

public class OnGuiScript : MonoBehaviour {

    public int movements;
    public int spawns;
    public int currentAverage;
    public int currentTime;
    private int localCounter = 0;

    void Start()
    {
        movements = 0;
        spawns = 0;
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
    }
}
