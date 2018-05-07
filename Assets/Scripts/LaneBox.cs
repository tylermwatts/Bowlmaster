using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBox : MonoBehaviour {

	private PinSetter pinSetter;

	void Start(){
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
	}

	void OnTriggerExit(Collider collider){
		if (collider.gameObject.name == "Ball"){
			pinSetter.ballOutOfPlay = true;
		}
	}
}
