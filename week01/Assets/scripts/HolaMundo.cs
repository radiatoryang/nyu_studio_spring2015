using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HolaMundo : MonoBehaviour {

	// if you see a line with a "//" that means it is a COMMENT
	// a COMMENT does not RUN as code

	// Use this for initialization
	void Start () {
		//Debug.Log ( "Bonjour Monde!" );
		//GetComponent<Text>().text = "Au Revoir Monde";
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log ( "Eat my shorts" );
		GetComponent<Text>().text = Time.time.ToString ();
	}
}
