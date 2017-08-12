using UnityEngine;
using System.Collections;

public class BattleState : GameState {
		
	protected override void OnStart()
	{

	}

	protected override void OnStop()
	{
		GUIManager.HideView("BattleState");
	}

	protected override void OnLoadingComplete()
	{
		GUIManager.ShowView("BattleState");
	}
}
