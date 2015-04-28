using UnityEngine;
using System.Collections;

public class BallSwap : MonoBehaviour {

	// assign all 3 in inspector
	public Transform ballA, ballB;
	public AudioClip impactSound;

	bool shouldIStopSwapping = false;

	// Use this for initialization
	void Start () {
		StartCoroutine ( BallCoroutine() );
	}

	// coroutine = a function where we control framerate / it last more than one frame
	IEnumerator BallCoroutine () {
		Debug.Log ( "hey the coroutine started" );
		yield return 0; // wait one frame
		Debug.Log ( "when we reach here, one frame has elapsed" );
		yield return new WaitForSeconds( 1f );
		Debug.Log ( "one more second elapsed!" );

		// an INFINITE LOOP is okay ONLY IN A COROUTINE
		while (true) {
			bool didIPlayASoundAlready = false;
			float percent = 0f;
			Vector3 ballAstart = ballA.position;
			Vector3 ballBstart = ballB.position;
			while ( percent < 1f ) {
				// increment percent
				percent += Time.deltaTime / 2f;
				// swap ball positions
				ballA.position = Vector3.Lerp ( ballAstart, ballBstart, percent );
				ballB.position = Vector3.Lerp ( ballBstart, ballAstart, percent );
				// play a sound when the 2 balls are on top of each other
				if ( percent >= 0.48f && didIPlayASoundAlready == false) {
					didIPlayASoundAlready = true;
					Debug.Log("trying to play sound!...");
					AudioSource.PlayClipAtPoint ( impactSound, ballA.position ); // temporarily create a gameobject just to play a sound there
					yield return StartCoroutine ( ScreenShake() ); // pause for as long as the coroutine is running
				}
				yield return 0; // wait a frame
			}
			if (shouldIStopSwapping == true) { break; } // break out of infinite loop, coroutine will terminate (see Update() )
			yield return 0; // wait a frame
		}
	}
	

	IEnumerator ScreenShake () {
		float percent = 1f;

		// remember the camera's position BEFORE we started shaking, otherwise we won't remember
		Vector3 cameraStartPosition = Camera.main.transform.position;
		while ( percent > 0f ) {
			percent -= Time.deltaTime / 0.2f; // subtract a fraction of a second from "percent"
			Vector3 cameraShakeOffset = Camera.main.transform.right * Mathf.Sin ( Time.time * 97f) 
										+ Camera.main.transform.up * Mathf.Sin ( Time.time * 47f);
			// actually apply the camera shake
			Camera.main.transform.position = cameraStartPosition + cameraShakeOffset * percent;
			yield return 0; // wait a frame
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			shouldIStopSwapping = true;
		}

//		if (Input.GetKeyDown (KeyCode.H) ) {
//			StartCoroutine ( ScreenShake () );
//		}

	}


}
