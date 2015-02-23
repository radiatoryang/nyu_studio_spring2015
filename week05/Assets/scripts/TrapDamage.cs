using UnityEngine;
using System.Collections;

public class TrapDamage : MonoBehaviour {

	Collider thingCurrentlyInside;
	public float damage = 100f;

	// Update is called once per frame
	void Update () {
		// if there is a thing currently inside this trigger...
		if ( thingCurrentlyInside != null ) {
			// then damage it.
			thingCurrentlyInside.GetComponent<Hurtable>().health -= Time.deltaTime * damage;
		}
	}

	// Unity automatically calls this function when an object with a Rigidbody
	// enters this object's trigger-collider, AND it will tell you WHAT entered it
	void OnTriggerEnter ( Collider activator ) {
		thingCurrentlyInside = activator; // want to remember the thing that entered the trigger
	}

	void OnTriggerExit ( Collider exiter ) {
		// "null" means nothing, empty, absence of anything
		thingCurrentlyInside = null;
	}

}




