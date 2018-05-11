using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;
		
	private Animator animator;
	private PinCounter pinCounter;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PerformAction(ActionMaster.Action action){
		if (action == ActionMaster.Action.Tidy){
			animator.SetTrigger("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn){
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();
		} else if (action == ActionMaster.Action.Reset){
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();
		} else if (action == ActionMaster.Action.EndGame){
			print ("Game Over");
		}
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
	
}
