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
	private string XMLPath = "Config";
	public TextAsset LoadComfigXML(string name)
	{
		return LoadXMLAsset (name, XMLPath);
	}

	public TextAsset LoadXMLAsset(string name, string path)//直接ResourcesLoad了，如果打算放AB下载，就做个判断，做个异步
	{
		TextAsset XMLAsset = null;
		string loadPath = path + "/" + name;
		XMLAsset = Resources.Load (loadPath, typeof(TextAsset)) as TextAsset;

		if (XMLAsset == null) {
			Debug.LogError("XMLAsset is null, loadPath: " + loadPath);
			return null;
		}
		return XMLAsset;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
