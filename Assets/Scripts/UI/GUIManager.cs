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

		Camera uiCamera = GameObject.FindWithTag ("UICamera").camera;		//实例化东西出来之后，指定一个物体
		if(uiCamera == null)
		{
			Debug.LogError("UICamera is null");
			return null;
		}
		UIPrefeb.transform.parent = uiCamera.transform;
		UIPrefeb.transform.localScale = new Vector3 (1, 1, 1);
		UIPrefeb.transform.localPosition = new Vector3 (prefeb.transform.localPosition.x, 
		                                               prefeb.transform.localPosition.y,
		                                                Mathf.Clamp (prefeb.transform.localPosition.z, -2f, 2f)); //层级关系
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
			panel = InstantiatePanel(name); 

			if(view == null || panel == null)
			{
				Debug.LogError("View or Panel is null, Name: " + name);
				return;
			}
			//设置层
			UIPanel[] childsPanel = panel.GetComponentsInChildren<UIPanel>(true);
			foreach(UIPanel childPanel in childsPanel)
			{
				childPanel.depth += (int)view.uiLayers;//保证显示
			}
			m_UIViewDic.Add(name, new KeyValuePair<GameObject, IView>(panel, view));

			view.Start();		//
		}else
		{

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
