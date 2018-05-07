using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	
	public Text standingDisplay;
	public GameObject pinSet;
	public bool ballOutOfPlay = false;

	private int lastStandingCount = -1;
	private float lastChangeTime;
	private int lastSettledCount = 10;
	
	private Animator animator;
	private Ball ball;
	// need ActionMaster here so that only one instance is created
	private ActionMaster actionMaster = new ActionMaster();

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString();
		if(ballOutOfPlay){
			UpdateStandingCountAndSettle();
			standingDisplay.color = Color.red;
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
		int standing = CountStanding();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;
		ActionMaster.Action action = actionMaster.Bowl(pinFall);
		if (action == ActionMaster.Action.Tidy){
			animator.SetTrigger("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn){
			animator.SetTrigger("resetTrigger");
			lastSettledCount = 10;
		} else if (action == ActionMaster.Action.Reset){
			animator.SetTrigger("resetTrigger");
			lastSettledCount = 10;
		} else if (action == ActionMaster.Action.EndGame){
			throw new UnityException("Don't know how to end game for now");
		}
		ball.Reset();
		lastStandingCount  = -1;
		ballOutOfPlay = false;
		standingDisplay.color = Color.green;
	}

	public void RaisePins(){
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Raise();
			pin.transform.rotation = Quaternion.Euler(270f, 0, 0);
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
}
