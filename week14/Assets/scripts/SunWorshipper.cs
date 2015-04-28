using UnityEngine;
using System.Collections;

public class SunWorshipper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( DayNightManager.instance.willTheSunBeOut == true )
			Debug.Log ("OH MY GOD I LOEV YOU THE SUN");
	}
}
