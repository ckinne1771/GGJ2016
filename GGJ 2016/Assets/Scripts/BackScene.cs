using UnityEngine;
using System.Collections;

public class BackScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void changeScene( int sceneToChangeTo )
	{
		Application.LoadLevel (sceneToChangeTo);
	}
}
