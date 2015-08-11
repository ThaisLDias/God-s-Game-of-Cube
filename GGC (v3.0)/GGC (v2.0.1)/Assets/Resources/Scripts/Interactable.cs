using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interactable : MonoBehaviour 
{

	void Start () 
	{
		if(PlayerPrefs.GetInt("level") < 1)
		{
			PlayerPrefs.SetInt("level",1);
		}

		string level = gameObject.transform.name;
		string leveled = level.Split('L')[1];
		leveled = level.Split('V')[1];
		if(PlayerPrefs.GetInt("level") < (int.Parse(leveled)))
		{
			gameObject.GetComponent<Button>().interactable = false;	
		}
	}
}
