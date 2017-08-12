using UnityEngine;
using System.Collections;
using System;

public class DownloadManager : MonoBehaviour {

	private static DownloadManager _Instance;
	public static DownloadManager Instance
	{
		get
		{
			if(_Instance == null)
			{
				_Instance = FindObjectOfType(typeof(DownloadManager)) as DownloadManager;
			}
			return _Instance;
		}
	}

	public delegate void LoadCallBack(params object[] args);  //做冗余

	public void LoadSceneBundle(string name, LoadCallBack loadHandler, params object[] args)
	{
		StartCoroutine (LoadSceneBundleAsync (name, loadHandler, args));
	}
	private IEnumerator LoadSceneBundleAsync(string name, LoadCallBack loadhandler, params object[] args)		//开一个协程去异步加载场景
	{
		AsyncOperation async = Application.LoadLevelAsync (name);
		yield return async;

		Resources.UnloadUnusedAssets ();
		GC.Collect ();  //卸载场景的时候手动调用GC回收

		if (loadhandler != null) {
			loadhandler(args);
		}
	}
}
