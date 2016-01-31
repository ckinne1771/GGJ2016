using UnityEngine;
using System.Collections;

public class Subtitles : MonoBehaviour {

	string subtitles;
	float timer;

	void OnGUI() {
		while (timer > 0.0f) {
			GUI.Label(new Rect(0.0f, Screen.height - 50.0f, Screen.width, 50.0f), subtitles);
			timer -= Time.deltaTime;
		}
	}

	public void update(string subtitle, float length) {
		subtitles = subtitle;
		timer = length;
	}
}
