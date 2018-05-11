using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour {

	private List<int> rolls = new List<int>();
	private List<int> boxes = new List<int>();
	private PinSetter pinSetter;
	private Ball ball;
	private ScoreDisplay scoreDisplay;

	void Start(){
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
		ball = GameObject.FindObjectOfType<Ball>();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}
	
	public void Bowl (int pinFall){
		try{
			rolls.Add(pinFall);
			boxes.Add(pinFall);
			ball.Reset();
			pinSetter.PerformAction(ActionMaster.NextAction(boxes));
		} catch {
			Debug.LogWarning ("Something went wrong in Bowl()");
		}
		try{
			scoreDisplay.FillRolls(rolls);
			scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
		} catch {
			Debug.LogWarning("FillRollCard not working");
		}
	}

}
