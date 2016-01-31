using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	static Sound instance;

	public AudioSource source;
	public Subtitles subtitleManager;

	void Start() {
		if (instance == null) {
			instance = this;
		}
	}

	public static void play(AudioClip clip) {
		instance.source.PlayOneShot(clip);
	}

	public static void dialogue(AudioClip clip, string subtitles, float length) {
		if (clip != null) {
			instance.source.PlayOneShot (clip);
			length = clip.length;
		}

		instance.subtitleManager.update(subtitles, length);
	}
}
