using UnityEngine;
using System.Collections;

public class NarrationTrigger : MonoBehaviour {
	
	public AudioClip clip;
	public string subtitles;
	public float length;

	void OnTriggerEnter(Collider other) {
		if (other.name.Equals("FPSController")) {
			Sound.dialogue(clip, subtitles, length);
		}
	}
}
