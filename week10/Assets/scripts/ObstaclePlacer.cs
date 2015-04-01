using UnityEngine;
using System.Collections;
using System.Collections.Generic; // you need this line to use Lists

// ObstaclePlacer places walls, remembers the walls it places,
// and if the player presses [K], then all walls are deleted...
// PLACE ON YOUR CAMERA

public class ObstaclePlacer : MonoBehaviour {

	public Transform obstaclePrefab; // assign in Inspector

	List<Transform> obstacleClones = new List<Transform>();
	
	void Update () {
		// generate a ray before shooting a raycast
		Ray cursorRay = Camera.main.ScreenPointToRay ( Input.mousePosition );

		// reserve in memory a "blank" object to hold impact data
		RaycastHit cursorRayInfo = new RaycastHit();

		// shoot the raycast
		if ( Physics.Raycast ( cursorRay, out cursorRayInfo, 1000f ) ) {
			Debug.Log ( "cursor is currently hovering over object " + cursorRayInfo.collider.name );

			// if the player right-clicked... GOOD JOB RICHARD
			if (Input.GetMouseButtonDown (1) ) {
				Transform newClone = (Transform)Instantiate ( obstaclePrefab, cursorRayInfo.point, Random.rotation );
				obstacleClones.Add ( newClone );
			}
		}

		// if the player presses K, rotate all walls by 90 degrees
		if (Input.GetKeyDown (KeyCode.K)) {
			foreach ( Transform clone in obstacleClones ) {
				clone.Rotate ( 0f, 90f, 0f, Space.World);
			}

		}


	}
}
