using UnityEngine;
using System.Collections;

public class CameraSet : MonoBehaviour {

	public float Width = 1280.0f;
	public float Height = 720.0f; //摄像机自适应
	
	// Update is called once per frame
	void Update () {
		if (Screen.width / Screen.height >= Width / Height) {
			camera.orthographicSize = Height / Screen.height;
		} else {
			camera.orthographicSize = Width / Screen.width;     	//自适应的时候都会缩小一点，也就是留出黑边
		}
	}
}
