﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	private ActionMaster actionMaster;

	[SetUp]
	public void Setup(){
		actionMaster = new ActionMaster();
	}

	[Test]
	public void T00_PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01_OneStrikeReturnsEndTurn(){
		Assert.AreEqual (endTurn, actionMaster.Bowl(10));
	}

	[Test]
	public void T02_Bowl8ReturnsTidy(){
		Assert.AreEqual(tidy, actionMaster.Bowl(8));
	}

	[Test]
	public void T03_Bowl28SpareReturnsEndTurn(){
		actionMaster.Bowl(8);
		Assert.AreEqual(endTurn, actionMaster.Bowl(2));
	}

	[Test]
	public void T04_CheckResetAtStrikeInLastFrame(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls){
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(reset, actionMaster.Bowl(10));
	}

	[Test]
	public void T05_CheckResetAtSpareInLastFrame(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls){
			actionMaster.Bowl(roll);
		}
		actionMaster.Bowl(1);
		Assert.AreEqual(reset, actionMaster.Bowl(9));
	}

	[Test]
	public void T06_YouTubeRollsEndInEndGame(){
		int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2};
		foreach (int roll in rolls){
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(endGame, actionMaster.Bowl(9));
	}

	[Test]
	public void T07_GameEndsAtBowl20(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1};
		foreach (int roll in rolls){
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(endGame, actionMaster.Bowl(1));
	}

	[Test]
	public void T08_TidyOnBowl20IfStrikeOn19ButNot20(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
		foreach (int roll in rolls){
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(tidy, actionMaster.Bowl(5));
	}

	[Test]
	public void T09_TidyOnBowl20GutterBall(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
		foreach (int roll in rolls){
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(tidy, actionMaster.Bowl(0));
	}
	[Test]
	public void T10_GutterBallSpareNotTreatedAsStrike(){
		int[] rolls = {0,10,5};
		foreach (int roll in rolls){
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(endTurn, actionMaster.Bowl(1));
	}

	[Test]
	public void T11_10thFrameTurkey(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		foreach (int roll in rolls){
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(reset, actionMaster.Bowl(10));
		Assert.AreEqual(reset, actionMaster.Bowl(10));
		Assert.AreEqual(endGame, actionMaster.Bowl(10));
	}
}