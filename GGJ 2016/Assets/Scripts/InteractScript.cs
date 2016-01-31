using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour {

	public GameObject player;
	public GameObject interactObject;

	public Texture2D crosshairTexture;
	public float crosshairScale = 1;

	public SpellCombinationScript spellScript;

	public GameObject Rune1;
	public GameObject Rune2;
	public GameObject Rune3;

	public bool isDialogue = true;
	public float dialogueTimer = 2;




	public Text dialogue;

	// Use this for initialization
	void Start () {
		Rune1.SetActive (false);
		Rune2.SetActive  (false);
		Rune3.SetActive  (false);


	}
	
	// Update is called once per frame
	void Update () {

		if (isDialogue == false) {
			dialogueTimer -= Time.deltaTime;
		
		}
		if (dialogueTimer <= 0) {
			dialogue.text = "";
			dialogueTimer = 2;
		}
	
	}

	void OnTriggerEnter( Collider other)
	{
		//interactObject = other.gameObject;
		if (other.gameObject.tag == "HeartTrig") {
			interactObject = other.gameObject;
		}

		if (other.gameObject.tag == "LightTrig") {
			interactObject = other.gameObject;
		}

		if (other.gameObject.tag == "FlashTrig") {
			interactObject = other.gameObject;
		}

		if (other.gameObject.tag == "QuakeTrig") {
			interactObject = other.gameObject;
		}

		if (other.gameObject.tag == "Rune1") {
			interactObject = other.gameObject;
			dialogue.text = "Press E to Interact";
			isDialogue = true;

		}
		if (other.gameObject.tag == "Rune2") {
			interactObject = other.gameObject;
			dialogue.text = "Press E to Interact";
			isDialogue = true;


		}
		if (other.gameObject.tag == "Rune3") {
			interactObject = other.gameObject;
			dialogue.text = "Press E to Interact";
			isDialogue = true;


		}
		else if (other.gameObject.tag == "Untagged")
		{
			isDialogue = false;
		}

		//Debug.Log ("Check");
		
	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "HeartTrig" && spellScript.heartActive == true) {
			Debug.Log ("LOVE YOU !");
			Destroy (interactObject);
		}

		if(other.gameObject.tag == "LightTrig" && spellScript.isAlight == true) {
			Debug.Log ("I CAST THEE OUT");
			Destroy (interactObject);
		}

		if (other.gameObject.tag == "FlashTrig" && spellScript.flash1stEffectTimer < 1) {
			Debug.Log ("Lighting!!!");
			Destroy (interactObject);
		}

		if (other.gameObject.tag == "QuakeTrig" && spellScript.shake > 0) {
			Debug.Log ("Shake!!!");
			Destroy (interactObject);
		}
		//dialogue.text = "Press E to Interact";


		if (Input.GetButtonDown ("Interact")) {
			if (other.gameObject.tag == "Rune1") {
				Debug.Log ("Beep");
				Rune1.SetActive (true);
				Destroy (interactObject);
				dialogue.text = "Rune 1 unlocked";
				isDialogue = false;



			}
			if (other.gameObject.tag == "Rune2") {
				Debug.Log ("Beep2");
				Rune2.SetActive (true);

				Destroy (interactObject);
				dialogue.text = "Rune 2 unlocked";
				isDialogue = false;


			}
			if (other.gameObject.tag == "Rune3") {
				Debug.Log ("Beep3");
				Rune3.SetActive (true);

				Destroy (interactObject);
				dialogue.text = "Rune 3 unlocked";
				isDialogue = false;

			} 
		}
		
	}

	void OnTriggerExit(Collider other)
	{
		interactObject = null;
		Debug.Log ("Goodbye");
		//dialogue.text = "";
	}

	void OnGUI()
	{

		if (crosshairTexture != null)
			GUI.DrawTexture (new Rect ((Screen.width - crosshairTexture.width * crosshairScale) / 2, (Screen.height - crosshairTexture.height * crosshairScale) / 2, crosshairTexture.width * crosshairScale, crosshairTexture.height * crosshairScale), crosshairTexture);
		else
			Debug.Log ("No crosshair texture set in the Inspector");
	}

}
