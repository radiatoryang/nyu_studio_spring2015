using UnityEngine;
using System.Collections;

public class LerpFollow : MonoBehaviour {

	public Transform followThis;

	// Update is called once per frame
	void Update () {
		// technically the "wrong way" to use lerp, but it's good enough for smoothing
		if ( Vector3.SqrMagnitude ( transform.position - followThis.position ) > 1f  )
			transform.position = Vector3.Lerp ( transform.position, followThis.position, Time.deltaTime * 5f );
	}

}
