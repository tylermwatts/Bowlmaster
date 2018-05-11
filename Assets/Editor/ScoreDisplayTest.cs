using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {
	
	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01_Bowl1(){
		int[] rolls = {1};
		string rollsString = "1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T02_Bowl1_8(){
		int[] rolls = {1,8};
		string rollsString = "18";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T03_Bowl_2_Frames(){
		int[] rolls = {1,8,4,4};
		string rollsString = "1844";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T04_BowlStrikeReturnsX(){
		int[] rolls = {10};
		string rollsString = "X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T05_Bowl2StrikesSkipsMiddleRoll(){
		int[] rolls = {10,10};
		string rollsString = "X X ";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T06_BowlStrikeOpenStrike(){
		int[] rolls = {10,8,4,10};
		string rollsString = "X 84X ";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T07_BowlTwelveStrikes(){
		int[] rolls = {10,10,10,10,10,10,10,10,10,10,10,10};
		string rollsString = "X X X X X X X X X XXX";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T08_TwentyRollsNoStrikes(){
		int[] rolls = {1,5,1,5,1,5,1,5,1,5,1,5,1,5,1,5,1,5,1,5};
		string rollsString = "15151515151515151515";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T09_HandlesSpares(){
		int[] rolls = {3,7};
		string rollsString = "3/";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T10_HandleGutterballSpare(){
		int[] rolls = {0,10};
		string rollsString = "-/";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T11_HandleAllSparesPlusFinalStrike(){
		int[] rolls = {0,10,0,10,0,10,0,10,0,10,0,10,0,10,0,10,0,10,0,10,10};
		string rollsString = "-/-/-/-/-/-/-/-/-/-/X";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T12_StrikeCallsXNotDash(){
		int[] rolls = {10};
		string rollsString = "X ";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
}
