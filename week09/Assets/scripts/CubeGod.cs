using UnityEngine;
using System.Collections;

public class CubeGod : MonoBehaviour {

	public Transform blueprint; // assign in Inspector
	int cubeCountMax = 100;
	float cubeSpawnRadius = 10f;

	// Use this for initialization
	void Start () {
		// ITERATION
		// ITERATION
		// ITERATIOnnnn

		// randomize system parameters
		cubeCountMax = Random.Range (100, 1000);
		cubeSpawnRadius = Random.Range ( 5f, 100f);

		// how to instantiate a cube, simply
		Instantiate ( 	blueprint, 
		             	new Vector3( 3.14f, 0.62f, 1f ), 
		             	Quaternion.Euler ( 0f, 180f, 0f ) 
		            );

		// how to instantiate multiple cubes
		int cubeCount = 0;
		while ( cubeCount < cubeCountMax ) {
			MakeRandomCube ();
			cubeCount = cubeCount + 1; // or "cubeCount++;" or "cubeCount += 1;"
		}
	}


	void MakeRandomCube () {
		Instantiate ( 	blueprint, 
		             	Random.onUnitSphere * cubeSpawnRadius, 
		             	Random.rotation
		             );
	}

	
	// Update is called once per frame
	void Update () {

		// a simple restart / regenerate button
		if ( Input.GetKeyDown (KeyCode.R) ) {
			Application.LoadLevel ( Application.loadedLevel );
		}

		if ( Input.GetKey (KeyCode.Space) ) {
			MakeRandomCube ();
		}

	}


}





