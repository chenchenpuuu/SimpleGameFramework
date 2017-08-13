using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class SceneData {

	public int ID;
	public string Name;		   //
	public string LevelName;   //场景的名字
	public string GameState;    //记录场景所属的状态
}

public class SceneDataManager
{
	private Dictionary<int, SceneData> m_SceneDataDic = null;

	public SceneData GetData(int key) 
	{
		if (m_SceneDataDic == null) {
			LoadSenceData();
		}
		if (!m_SceneDataDic.ContainsKey (key)) {
			Debug.LogError("the key in SceneConfig is null, key: " + key);
		}

		return m_SceneDataDic [key];
	}
	private void LoadSenceData()
	{
		if (m_SceneDataDic == null) {
			m_SceneDataDic = new Dictionary<int, SceneData> ();
		}
		string textAsset = ResourcesManager.Instance.LoadComfigXML("SceneData").text;
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.LoadXml (textAsset);
		XmlNode equipXN = xmlDoc.SelectSingleNode("SceneDatas"); 

		XmlNodeList list = equipXN.ChildNodes;
		if (list != null && list.Count > 0) {
			foreach(XmlNode node in list)
			{
				XmlElement element = node as XmlElement;
				if(element.Name.Equals("SceneData"))
				{
					SceneData info = new SceneData();
					info.ID = CommonHelper.Str2Int(element.GetAttribute("ID"));
					info.Name = element.GetAttribute("Name");
					info.LevelName = element.GetAttribute("LevelName");
					info.GameState = element.GetAttribute("GameState");

					if(!m_SceneDataDic.ContainsKey(info.ID))
					{
						m_SceneDataDic.Add(info.ID, info);
					}
				}
			}
		}
	}
}
/*

<?xml version="1.0" encoding="UTF-8"?>
<!-- SceneData: 场景配置   Name: 场景名字  LevelName: 场景资源名字  Desc: 场景描述（无用） GameState: 场景调用逻辑 -->
<SceneDatas>
	<SceneData ID="1" Name="login" LevelName="login" Desc="登陆场景" GameState="LoginState"/>
	<SceneData ID="2" Name="city" LevelName="city_home02" Desc="主城场景1" GameState="CityState"/>
	<SceneData ID="3" Name="dungeon01" LevelName="map_plain_changbanpo01" Desc="旧大地图" GameState="DungeonState"/>
	<SceneData ID="4" Name="battle01" LevelName="demo2_scene01" Desc="战斗场景1" GameState="BattleState"/>
	<SceneData ID="5" Name="battle02" LevelName="login" Desc="登陆场景" GameState="LoginState"/>
	<SceneData ID="6" Name="login" LevelName="login" Desc="登陆场景" GameState="LoginState"/>
	<SceneData ID="7" Name="login" LevelName="login" Desc="登陆场景" GameState="LoginState"/>
	<SceneData ID="8" Name="login" LevelName="login" Desc="登陆场景" GameState="LoginState"/>
	<SceneData ID="9" Name="login" LevelName="login" Desc="登陆场景" GameState="LoginState"/>
</SceneDatas>

 */