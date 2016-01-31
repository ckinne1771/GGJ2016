using UnityEngine;
using System.Collections;

public class IntroNarration : MonoBehaviour {

	public AudioSource source;
	public AudioClip[] clips;
	
	public string[] subtitles;
	public float[] timings;

	int index = 0;

	void Start() {
		source.PlayOneShot(clips[0]);
		Invoke("playSecondClip", clips[0].length);
	}

	void OnGUI() {
		if (index < subtitles.Length) {
			timings[index] -= Time.deltaTime;
			GUI.Label(new Rect(0.0f, Screen.height - 50.0f, Screen.width, 50.0f), subtitles[index]);

			if (timings[index] <= 0.0f) {
				index++;
			}
		}
	}

	void playSecondClip() {
		source.PlayOneShot(clips[1]);
	}
}
