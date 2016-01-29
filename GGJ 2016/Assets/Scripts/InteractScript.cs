using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour {

	public GameObject player;
	public GameObject interactObject;

	public Text dialogue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter( Collider other)
	{
		interactObject = other.gameObject;
		Debug.Log ("Check");
		
	}

	void OnTriggerStay(Collider other)
	{
		dialogue.text = "Press E to Interact";

		if (Input.GetButtonDown("Interact"))
			{
				Debug.Log("Beep");
			}
		
	}

	void OnTriggerExit(Collider other)
	{
		interactObject = null;
		Debug.Log ("Goodbye");
		dialogue.text = "";
	}

}
