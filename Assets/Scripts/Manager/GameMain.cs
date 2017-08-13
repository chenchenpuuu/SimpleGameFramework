using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour {

	void Start () {
		gameObject.AddComponent<DownloadManager> ();
		gameObject.AddComponent<GameStateManager> ();
	}
	
	void Update () {
	
	}
}
