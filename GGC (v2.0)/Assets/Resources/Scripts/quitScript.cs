using UnityEngine;
using System.Collections;

public class quitScript : MonoBehaviour {

	// Use this for initialization
	public void OnMouseDown () {
		Debug.Log ("Quit");
		Application.Quit ();
	}
	

}
