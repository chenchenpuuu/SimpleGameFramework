using UnityEngine;
using System.Collections;

public class CityState : GameState {

	protected override void OnStart()
	{

	}

	protected override void OnStop()
	{
		GUIManager.HideView("PlayerState");
	}

	protected override void OnLoadingComplete()
	{
		GUIManager.ShowView("PlayerPanel");
	}
}
