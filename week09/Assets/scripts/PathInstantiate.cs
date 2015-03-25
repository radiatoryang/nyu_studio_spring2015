using UnityEngine;
using System.Collections;

// put this on a small cube, it will move around and drop floor modules like breadcrumbs
public class PathInstantiate : MonoBehaviour {

	int tilesPlacedCounter = 0;
	public Transform floorTilePrefab; // assign in Inspector
	
	void Update () {
		// stop going after we've placed 50 tiles
		if ( tilesPlacedCounter < 50 ) {

			// randomly turn sometimes
			float random = Random.Range (0f, 1f);
			if ( random < 0.25f ) { // 25% chance
				transform.Rotate ( 0f, 90f, 0f );
			} else if ( random < 0.5f ) { // 25% chance
				transform.Rotate ( 0f, -90f, 0f );
			}

			// make a new clone of tilePrefab at our current position
			Instantiate ( floorTilePrefab, transform.position, Quaternion.Euler (0, 0, 0) );

			// move forward by 5 units
			transform.position += transform.forward * 5f; 

			// increment counter
			tilesPlacedCounter++;
		} else {
			// if we've placed enough tiles, then self-destruct
			Destroy ( gameObject );
		}
	}
}
