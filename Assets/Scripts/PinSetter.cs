using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text standingDisplay;
	public float distanceToRaise = 40f;
	
	private float lastChangeTime;
	private bool ballEnteredBox;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString();
		if(ballEnteredBox){
			CheckStanding();
		}
	}

	public void RaisePins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if (pin.IsStanding()){
				pin.transform.Translate (new Vector3 (0, distanceToRaise, 0), Space.World);
			}
		}
	}

	public void LowerPins(){

	}

	public void RenewPins(){

	}

	void CheckStanding(){
		int currentStanding = CountStanding(); 
		if (currentStanding != lastStandingCount){
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}
		float settleTime = 3f;
		if ((Time.time - lastChangeTime) > settleTime){
			PinsHaveSettled();
		}
	}

	void PinsHaveSettled(){
		ball.Reset();
		lastStandingCount  = -1;
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
	}



	int CountStanding(){
		int standingPinCount = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if (pin.IsStanding()){
				standingPinCount++;
			}
		}
		return standingPinCount;
	}

	void OnTriggerEnter(Collider collider){
		GameObject thingHit = collider.gameObject;
		if (thingHit.GetComponent<Ball>()){
			ballEnteredBox = true;
			standingDisplay.color = Color.red;
		}
	}

	void OnTriggerExit (Collider collider){
		GameObject thingLeft = collider.gameObject;
		if (thingLeft.GetComponent<Pin>()){
			Destroy(thingLeft);
		}
	}
}
