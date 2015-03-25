using UnityEngine;
using System.Collections;

public class CubeSpin : MonoBehaviour {

	float spinSpeed;

	// Use this for initialization
	void Start () {
		spinSpeed = Random.Range (90f, 270f);
	}
	
	// Update is called once per frame
	void Update () {
		// spin
		transform.Rotate (0f, Time.deltaTime * spinSpeed, 0f );

		// wiggle, will eventually drift, OH WELL
		transform.Translate ( Random.insideUnitSphere * 0.1f );
	}
}
