using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class GUIManager {
	private static Dictionary<string, KeyValuePair<GameObject, IView>> m_UIViewDic = new Dictionary<string, KeyValuePair<GameObject, IView>> ();//panel的名字 panel的物体 管理panel的类

	private static GameObject InstantiatePanel(string prefebName)
	{
		GameObject prefeb = ResourcesManager.Instance.GetUIPrefeb (prefebName);
		if(prefeb == null)
		{
			Debug.LogError("prefeb is null, prefebName:" + prefebName);
			return prefeb;
		}
		GameObject UIPrefeb = GameObject.Instantiate (prefeb) as GameObject; //实例化
		UIPrefeb.name = prefebName;
		return UIPrefeb;
	}

	public static void ShowView(string name) 
	{
		IView view = null;
		GameObject panel = null;

		KeyValuePair<GameObject, IView> found;
		if (!m_UIViewDic.TryGetValue (name, out found)) 
		{
			view = Assembly.GetExecutingAssembly().CreateInstance(name) as IView;
			//panel 
		}
	}

	public static void HideView(string name)
	{

	}

	public static void DestroyAllView()
	{

	}

	public static IView FindView(GameObject go)
	{
		IView view = null;
		return view;
	}
}
