using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 5f;
	public float distanceToRaise = 40f;

	private Rigidbody rigidBody;

	void Start (){
		rigidBody = GetComponent<Rigidbody>();
	}

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

	public void Raise(){
		if (IsStanding()){
			rigidBody.useGravity = false;
			transform.Translate (new Vector3 (0, distanceToRaise, 0), Space.World);
		}
		
	}

	public void Lower(){
		if (IsStanding()){
			transform.Translate (new Vector3 (0, -distanceToRaise, 0), Space.World);
			rigidBody.useGravity = true;
		}
	}

	public void Renew(){
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.useGravity = false;
		rigidBody.freezeRotation = true;
	}
}
