using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class GameStateManager : MonoBehaviour {
	private static Dictionary<string, GameState> m_GameStateMap = null; //状态的MAP
	private static GameState m_CurGameState = null;

	void Start () {
		m_GameStateMap = new Dictionary<string, GameState> ();
		m_CurGameState = null;
		//load场景
		LoadScene (1);//还没表 加点假数据
	}

	private static void SetState(GameState state)
	{
		if (state == null) {
			return;
		}
		if (state != m_CurGameState && m_CurGameState != null) {
			m_CurGameState.Stop();
		}
		m_CurGameState = state;
		m_CurGameState.Start ();
	}
	
	public static void LoadScene (int SceneId) {  //每个场景配置在表里，根据SceneId去加载场景

		SceneData data = DataManager.s_SceneDataManager.GetData (SceneId);
		data.LevelName = "login";
		data.GameState = "LoginState";
		if (data == null) {
			Debug.LogError("Init SceneData is null, SceneId:" + SceneId);
			return;
		}

		GameState state = null;  //类名反射，用字符串创建一个类的对象
		if (!m_GameStateMap.TryGetValue (data.GameState, out state)) {
			state = Assembly.GetExecutingAssembly().CreateInstance(data.GameState) as GameState;
			if(state == null)
			{
				Debug.LogError("Scene state is error, data.GameState:" + data.GameState);
				return;
			}
			m_GameStateMap.Add (data.GameState, state);
		}
		SetState (state);

		// 状态设置完毕,开始LoadScene
		DownloadManager.Instance.LoadSceneBundle (data.LevelName, state.LoadingComplete);
	}

}
