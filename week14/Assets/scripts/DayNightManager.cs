using UnityEngine;
using System.Collections;

using UnityEngine.UI;


public enum TimeOfDay { Morning, Afternoon, Evening, Midnight, MAX_COUNT }

public class DayNightManager : MonoBehaviour {

	// the "static" keyword makes things "live" in the code,
	// not necessarily in the scene
	// (e.g. if we made 20 gameobjects, they would all point
	// to this same variable)
	public static DayNightManager instance;

	public Light sun; // assign in inspector
	public TimeOfDay currentTime;

	float progress = 0f; // when progress is 1.0, go to next stage

	public bool willTheSunBeOut = false; // doesn't actually do anything

	public Slider timeSlider; // assign in inspector

	// Use this for initialization
	void Awake () {
	//	instance = GetComponent<DayNightManager>();
		instance = this;
	}

	// PUBLIC VOID FOR UI
	public void SetSliderDayCycle( float phase ) {
		currentTime = (TimeOfDay)Mathf.RoundToInt (phase);
	}

	// functions must be PUBLIC VOID in order for UI to call it
	public void AdvanceDayCycle () {
//		currentTime = (TimeOfDay)currentTime++;
//		if ( currentTime == TimeOfDay.MAX_COUNT ) {
//			currentTime = TimeOfDay.Morning;
//		}
		// our actual state machine code is in Update

		progress = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		progress += Time.deltaTime / 5f;

		if ( progress >= 1f ) {
			progress = 0f;
			timeSlider.value = (int)currentTime; // update UI slider
			switch ( currentTime ) {
				case TimeOfDay.Morning:
					willTheSunBeOut = true;
					currentTime = TimeOfDay.Afternoon;
					sun.transform.localEulerAngles = new Vector3( 50f, 0f, 0f); // afternoon
					break;
				case TimeOfDay.Afternoon:
					willTheSunBeOut = false;
					currentTime = TimeOfDay.Evening;
					sun.transform.localEulerAngles = new Vector3( 130f, 0f, 0f); // evening
					break;
				case TimeOfDay.Evening:
					willTheSunBeOut = false;
					currentTime = TimeOfDay.Midnight;
					sun.transform.localEulerAngles = new Vector3( 200f, 0f, 0f); // midnight
					break;
				case TimeOfDay.Midnight:
					willTheSunBeOut = true;
					currentTime = TimeOfDay.Morning;
					sun.transform.localEulerAngles = new Vector3( 10f, 0f, 0f); // morning
					break;
			} // end switch
		} // end progress IF


	}
}





