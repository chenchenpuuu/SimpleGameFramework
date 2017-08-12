using UnityEngine;
using System.Collections;

public class ResourcesManager : MonoBehaviour {
	private static ResourcesManager _Instance = null;
	public static ResourcesManager Instance
	{
		get
		{
			if(_Instance == null)
			{
				_Instance = new ResourcesManager();
			}
			return _Instance;
		}
	}
	private string UIPanelPath = "UI/Panel";		//TODO 写一个资源管理类
	public GameObject GetUIPrefeb(string name) 
	{
		return LoadPrefeb (name, UIPanelPath);
	}

	public GameObject LoadPrefeb(string name, string path)
	{
		string loadPath = UIPanelPath + "/" + name;
		GameObject prefeb = Resources.Load (loadPath, typeof(GameObject)) as GameObject;  //加载
		if(prefeb == null)
		{
			Debug.LogError("prefeb is null, loadPath:" + loadPath);
		}
		return prefeb;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
