using UnityEngine;
using System.Collections;

public class Richard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// move forward if I press W
		// GetKeyDown = tapping, GetKey = holding
		if ( Input.GetKey ( KeyCode.W ) ) 
		{ // Time.deltaTime is the fraction of a second in between a frame
	      // a value that gets bigger with low FPS, smaller with high FPS
			transform.position += new Vector3( 0f, 0f, 10f ) * Time.deltaTime;
		}

		// FRAMERATE-DEPENDENT
		// if I have more FPS, I go faster

		// FRAMERATE-INDEPENDENT
		// no matter what your framerate, you get same behavior



		// move backward if I press S

		// move left if I press A

		// move right f I press D
	}
}
