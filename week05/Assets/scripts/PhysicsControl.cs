using UnityEngine;
using System.Collections;

public class PhysicsControl : MonoBehaviour {

	public float speed = 5f;
	public float turnSpeed = 45f;
	Rigidbody rbody;

	void Start () {
		// "caching" a reference to the rigidbody
		rbody = GetComponent<Rigidbody>();
	}

	// FixedUpdate is called on a fixed interval / every physics frame
	// you'll want to use FixedUpdate for doing anything with physics
	void FixedUpdate () {

		// INPUT AXES: a virtual joystick that returns a float from -1 to 1
		rbody.AddForce ( transform.forward * speed * Input.GetAxis("Vertical") );

		// comment out for sideways movement
		// rbody.AddForce ( transform.right * speed * Input.GetAxis("Horizontal") );

		// TURNING
		transform.Rotate ( 0f, Input.GetAxis ("Horizontal") * turnSpeed, 0f );
	}
}




