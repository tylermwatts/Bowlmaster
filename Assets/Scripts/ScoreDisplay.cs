using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreDisplay : MonoBehaviour {

	public Text[] scoreBoxes = new Text[21];
	public Text[] frameScores = new Text[10];

	public void FillRolls(List<int> rolls){
		string scoresString = FormatRolls(rolls);
		for (int i = 0; i < scoresString.Length; i++){
			scoreBoxes[i].text = scoresString[i].ToString();
		}			
	}

	public void FillFrames(List<int> frames){
		for (int i = 0; i < frames.Count; i++){
			frameScores[i].text = frames[i].ToString();
		}
	}

	public static string FormatRolls(List<int> rolls){
		// make a string of 21 rolls to fill each roll score
		string output = "";
		int strikes = 0;
		List<string> outputString = new List<string>();
		for (int i = 0; i < rolls.Count; i++){
			if (rolls[i] == 10){										// increment number of strikes to keep track of frames
				strikes++;
			}
			if (strikes <= 9 && rolls[i] == 10){						// Adds "X" plus a space for frames 1 - 9 for STRIKES
				outputString.Add("X");
				outputString.Add(" ");
			} else if (strikes >= 10 && rolls[i] == 10){				// Adds "X" without a space for frame 10 if 3 STRIKES
				outputString.Add("X");
			} else {													// Adds the rolls together for OPEN frames
				outputString.Add(rolls[i].ToString());
			}
		}
		output = string.Join("", outputString.ToArray());
		return output;
	}

}
