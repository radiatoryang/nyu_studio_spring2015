using UnityEngine;
using System.Collections;

// put this on an empty gameobject or wherever
public class SimpleRestart : MonoBehaviour {
	
	void Update () {
		// did the player press [R] on the keyboard?
		if (Input.GetKeyDown (KeyCode.R)) {
			// if so, reload the current scene
			Application.LoadLevel ( Application.loadedLevel );
		}
	}

}
