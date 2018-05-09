using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {

	public static List <int> ScoreCumulative(List<int> rolls){
		List<int> cumulativeScores = new List<int>();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames(rolls)){
			runningTotal += frameScore;
			cumulativeScores.Add(runningTotal);
		}

		return cumulativeScores;
	}

	public static List<int> ScoreFrames(List<int> rolls){
		List<int> frames = new List<int> ();

		for (int i = 1; i < rolls.Count; i += 2){
			if (frames.Count == 10){					// Breaks loop on last frame
				break;
			}
			if((rolls[i-1] + rolls[i]) < 10){			// Normal open frame
			frames.Add(rolls[i - 1] + rolls [i]);
			}
			if (rolls.Count - i <= 1){					// Insufficient look-ahead (i+=2)
				break;
			}
			if (rolls[i-1] == 10){						// Strike
				i--;									// Decrement i (because i+=2) to add strike bonus
				frames.Add(10 + rolls[i+1] + rolls[i+2]);
			} else if((rolls[i-1] + rolls[i]) == 10){	// Spare
				frames.Add(10 + rolls[i+1]);
			}
		}

		return frames;
	}

}