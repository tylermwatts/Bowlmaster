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
		for (int i = 0; i < rolls.Count; i++){
			int roll = output.Length + 1;

			if (rolls[i] == 0){																// Always enter 0 as -
				output += "-";
			} else if ((roll % 2 == 0  || roll == 21) && (rolls[i - 1] + rolls[i]) == 10){	// SPARES
				output += "/";
			} else if (roll >= 19 && rolls[i] == 10){										// STRIKE in last frame
				output += "X";
			} else if (rolls[i] == 10){														// Counts # of STRIKES for frames 1 - 9
				output += "X ";
			} else {																		// Adds the rolls together for OPEN frames
				output += rolls[i].ToString();
			}
		}
		return output;
	}

}
