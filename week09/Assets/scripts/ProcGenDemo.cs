using UnityEngine;
using System.Collections;

public class ProcGenDemo : MonoBehaviour {

	public GameObject prefab;

	// Use this for initialization
	void Start () {
		// simple instantiation
		Instantiate ( prefab, 
		              new Vector3( Random.Range (-100f, 100f), 0f, Random.Range (-50f, 50f) ), 
		              Quaternion.Euler ( 0f, Random.Range (0, 360), 0f )
		            );

		// instantiation in a while loop
//		int counter = 0;
//		while ( counter < 50 ) {
//			Instantiate ( prefab, 
//			             new Vector3( Random.Range (-10f, 10f), 0f, Random.Range (-10f, 10f) ), 
//			             Quaternion.Euler ( 0f, Random.Range (0, 360), 0f )
//			             );
//			counter++;
//		}

		// instantiation in a for loop
		for ( int anotherCounter = 0; anotherCounter < 1000; anotherCounter += 1 ) {
			Instantiate ( prefab, 
			             new Vector3( Random.Range (-10f, 10f), 0f, Random.Range (-10f, 10f) ), 
			             Quaternion.Euler ( 0f, Random.Range (0, 360), 0f )
			            );
		}

	}
	
	// Update is called once per frame
	void Update () {

	}
}
