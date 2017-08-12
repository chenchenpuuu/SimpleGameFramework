using UnityEngine;
using System.Collections;

public abstract class GameState  {

	public void Start()
	{
		GUIManager.ShowView ("LoadingPanel");
		OnStart ();
	}

	public void Stop()
	{
		OnStop ();
	}

	public void LoadingComplete(params object[] args)
	{
		OnLoadingComplete ();
		GUIManager.HideView("LoadingPanel"); 
	}

	protected abstract void OnStart();
	protected abstract void OnStop();
	protected abstract void OnLoadingComplete();
}