using UnityEngine;
using System.Collections;

// we need this line to use Lists
using System.Collections.Generic;

// it doesn't really matter where you put this script as long as there's just one copy per scene
// but I chose to put mine on my Main Camera, since it uses some camera functions
public class NPCCommand : MonoBehaviour {

	public NPCRaycast npcPrefab; // assign in inspector

	// this is a List of references to NPC objects, specifically the NPC clones we instantiate
	public List<NPCRaycast> allMyNpcs = new List<NPCRaycast>();

	// Update is called once per frame
	void Update () {
		// first: find out where the player is clicking
		// take player's mouse cursor position, and "project" out from camera's facing
		Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );

		// if we want "forensics" information about where the raycast hit, we need a blank variable
		RaycastHit rayHit = new RaycastHit();

		if ( Physics.Raycast ( ray, out rayHit, 1000f ) ) {
			// now, if player clicks and NOT on an NPC, then instantiate a new NPC
			if ( Input.GetMouseButtonDown (0) && rayHit.collider.tag != "Player" ) {
				Vector3 spawnPosition = rayHit.point + rayHit.normal;
				// if you want to REMEMBER the clone you instantiate, make sure you cast the type ("as Raycast") at the end
				NPCRaycast newNPC = Instantiate ( npcPrefab, spawnPosition, Quaternion.Euler (0, 0, 0) ) as NPCRaycast;
				allMyNpcs.Add ( newNPC ); // add the clone to the list of NPCs (see above)
			}
		}

		// if we press R, then go through the entire list and multiply each NPC's speed by 2
		if ( Input.GetKeyDown (KeyCode.R) ) {
			// "var" infers the type based on available information. In this case, we already know allMyNpcs is a list of NPCRaycast objects
			foreach ( var thisNPC in allMyNpcs ) { // "foreach" is a shortcut "for" loop designed for iterating through arrays and lists
				thisNPC.speed *= 2f; // we can access "speed" from this script because it is a public variable in NPCRaycast.cs
			}
		}


	}
}


