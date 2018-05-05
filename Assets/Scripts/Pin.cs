using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 5f;

	void Update(){
		
	}

	public bool IsStanding(){
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		float titltInX = Mathf.Abs(270 - rotationInEuler.x);
		float tiltInZ = Mathf.Abs(rotationInEuler.z);
		if (titltInX < standingThreshold && tiltInZ < standingThreshold){
			return true;
		} else {
			return false;
		}
	}
}
