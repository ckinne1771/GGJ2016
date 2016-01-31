using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
	//public GameObject menuMusic;

	public void Start(){
		
	}


	public void changeScene( int sceneToChangeTo )
	{
		Application.LoadLevel (sceneToChangeTo);
	}


}