using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float speed = 5f; // "public" exposes it in the Inspector

	// a declare a public "Text" to tell Unity which "Text" object I mean
	public Text uiText; // assign this in the inspector
	
	// Update is called once per frame
	void Update () {
	
		// Time.deltaTime = FRAMERATE INDEPEDENT BEHAVIOR
		if (Input.GetKey (KeyCode.W)) {
			uiText.text = "I'm moving forward!"; // set data on the other object
			Debug.Log( uiText.transform.position ); // read data from the other object
			transform.position += transform.forward * Time.deltaTime * speed;
		}
		if (Input.GetKey (KeyCode.S)) {
			uiText.text = "I'm moving backward!";
			transform.position -= transform.forward * Time.deltaTime * speed;
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += transform.right * Time.deltaTime * speed;
		}

		// Vector3.forward = worldspace
		// transform.forward = object space, local space 
		// 		(which takes rotation into account)

		if (Input.GetKey (KeyCode.A)) {
			// when you hardcode a constant value, we call that a "magic number"
			transform.Rotate (0f, 90f * Time.deltaTime, 0f);
		}
	}
}
