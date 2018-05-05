using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text standingDisplay;
	public GameObject pinSet;
	
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
			UpdateStandingCountAndSettle();
		}
	}

	void UpdateStandingCountAndSettle(){
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

	public void RaisePins(){
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Raise();
		}
	}

	public void LowerPins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Lower();
		}
	}

	public void RenewPins(){
		Instantiate (pinSet, new Vector3 (0, 41, 1829), Quaternion.identity);
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Renew();
		}
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
}
