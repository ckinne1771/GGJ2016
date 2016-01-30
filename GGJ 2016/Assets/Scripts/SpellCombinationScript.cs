using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class SpellCombinationScript : MonoBehaviour
{

	public GameObject fpCamera;

	List<int> spellCombinations = new List<int>();

	bool element1Active = false;
	bool element2Active = false;
	bool element3Active = false;

	bool maxSelection = false;

	int spellsSelected = 0;

	public GameObject player;

	public float freezeTimer = 3.0f;
	private bool isFrozen = false;
	private bool isAlight = false;

	//Heart Spell
	public GameObject HeartParticles;
	public float heartTimer = 5.0f;
	private bool heartActive = false;

	//Light Spell
	public float lightTimer = 10.0f;
	public GameObject selfLight;

	//Blind Spell
	public float blindTimer = 2.0f;
	public bool isBlinded = false;

	//Scream Spell
	public GameObject scream;
	public AudioClip screaming;

	//Smoke Spell
	public GameObject smoke;
	//private bool smokeActive = false;
	public float pooTimer = 2;

	//Flashed Spell Update
	public BloomAndFlares BandF;
	public GameObject flash1stEffect;
	public float flash1stEffectTimer;
	private bool flashBool = false;

	//drunkMathew var.
	public float drunkTimer;

	//QuakeState var.
	public float shake = 0;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1;

	//Psy Spell
	public bool isPsy;
	public float psyLimit;

	// Use this for initialization
	void Start()
	{

		//Heart Spell
		HeartParticles.SetActive(false);

		//Smoke Spell
		//smoke.SetActive(false);

		//Light Spell
		selfLight.SetActive(false);

		//flash spell Effect 1 setup
		flash1stEffect.SetActive(false);
		flash1stEffectTimer = 1;
		//flash spell Effect 2 setup
		BandF = fpCamera.GetComponent<BloomAndFlares>();
		BandF.bloomIntensity = 0;

		//drunkMathew setup
		drunkTimer = 3;
		fpCamera.GetComponent<MotionBlur>().enabled = false;

		//Psy Spell
		psyLimit = 5;

	}

	// Update is called once per frame
	void Update()
	{

		//Making Spell

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			if (spellsSelected < 3)
			{
				int el1 = 1;
				spellCombinations.Add(el1);
				spellsSelected++;
			}
			else
			{
				Debug.Log("Spell Combinations Maxed");
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			if (spellsSelected < 3)
			{
				int el2 = 2;
				spellCombinations.Add(el2);
				spellsSelected++;
			}
			else
			{
				Debug.Log("Spell Combinations Maxed");
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			if (spellsSelected < 3)
			{
				int el3 = 3;
				spellCombinations.Add(el3);
				spellsSelected++;
			}
			else
			{
				Debug.Log("Spell Combinations Maxed");
			}
		}

		//Scream Spell
		//Screaming();

		//DrunkMathew Spell
		//drunkMathew();

		//shake Spell
		//quakeState();

		//pyc Spell
		//psySpell();

		//Fire Spell
		if (Input.GetMouseButtonDown(0))
		{
			if (spellsSelected == 3)
			{
				//Debug.Log("Spell Cast" + spellCombinations[0].ToString() + spellCombinations[1].ToString() + spellCombinations[2].ToString());
				castASpell();

				spellCombinations.Clear();
				spellsSelected = 0;
			}
			else
			{
				Debug.Log("Not enough spells selected");
			}
		}



		//Paralyse Spell Eff.
		if (isFrozen == true && freezeTimer > 0)
		{
			freezeTimer -= Time.deltaTime;
			Debug.Log(freezeTimer.ToString());
		}
		else if (freezeTimer <= 0)
		{
			isFrozen = false;
			player.GetComponent<FirstPersonController>().enabled = true;
			freezeTimer = 3;
		}

		//Blind Spell Eff.
		if (isBlinded == true && blindTimer > 0)
		{
			blindTimer -= Time.deltaTime;
			Debug.Log(blindTimer.ToString());
		}
		else if (blindTimer <= 0)
		{
			isBlinded = false;
			fpCamera.GetComponent<Camera>().cullingMask = (1);
			blindTimer = 4;
		}

		//Heart Spell Eff.
		if (heartActive == true && heartTimer > 0)
		{
			heartTimer -= Time.deltaTime;
			Debug.Log(blindTimer.ToString());
		}
		else if (heartTimer <= 0)
		{
			heartActive = false;
			HeartParticles.SetActive(false);
			heartTimer = 5;
		}

		//Light Spell Eff.
		if (isAlight == true && lightTimer > 0)
		{
			lightTimer -= Time.deltaTime;
		}
		else if (lightTimer <= 0)
		{
			isAlight = false;
			selfLight.SetActive(false);
			lightTimer = 10;
		}

		//Flashed Spell Eff. 
		if (flashBool == true && BandF.bloomIntensity == 0)
		{
			flash1stEffect.SetActive(true);
			BandF.bloomIntensity = 100;
		}
		if (flashBool == true && BandF.bloomIntensity == 100)
		{
			flashBool = false;
		}

		if (flash1stEffect.active == true)
		{
			flash1stEffectTimer -= Time.deltaTime;
		}
		if (flash1stEffectTimer <= 0)
		{
			flash1stEffect.SetActive(false);
			flash1stEffectTimer = 1;
		}

		if (BandF.bloomIntensity > 0)
		{
			BandF.bloomIntensity -= 1;
		}
		if (BandF.bloomIntensity < 0)
		{
			BandF.bloomIntensity = 0;
		}

		if (fpCamera.GetComponent<ColorCorrectionCurves>().enabled == true)
		{
			psyLimit -= Time.deltaTime;
		}

		if (psyLimit <= 0)
		{
			fpCamera.GetComponent<ColorCorrectionCurves>().enabled = false;
			psyLimit = 5;
		}

		if (shake > 0)
		{
			fpCamera.transform.localPosition = Random.insideUnitSphere * shakeAmount;
			shake -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shake = 0;
		}

		if (fpCamera.GetComponent<MotionBlur>().enabled == true)
		{
			drunkTimer -= Time.deltaTime;
		}

		if (drunkTimer <= 0)
		{
			fpCamera.GetComponent<MotionBlur>().enabled = false;
			drunkTimer = 3;
		}

		if (smoke.active == true) {
			pooTimer -= Time.deltaTime;
		}

		if(pooTimer <= 0)
		{
			smoke.SetActive(false);
			pooTimer = 2;
		}

	}



	//SpellBook List
	void castASpell()
	{
		//Paralysis Spell
		if (spellCombinations [0] == 2 && spellCombinations [1] == 3 && spellCombinations [2] == 1) {
			paralysis ();
		} else if (spellCombinations [0] == 3 && spellCombinations [1] == 3 && spellCombinations [2] == 2) {
			blindness ();
		} else if (spellCombinations [0] == 1 && spellCombinations [1] == 1 && spellCombinations [2] == 1) {
			hearts ();
		} else if (spellCombinations [0] == 1 && spellCombinations [1] == 1 && spellCombinations [2] == 3) {
			Flashed ();
		} else if (spellCombinations [0] == 3 && spellCombinations [1] == 2 && spellCombinations [2] == 3) {
			light ();
		} else if (spellCombinations [0] == 2 && spellCombinations [1] == 1 && spellCombinations [2] == 3) {
			Screaming (); //Check
		} else if (spellCombinations [0] == 3 && spellCombinations [1] == 1 && spellCombinations [2] == 1) {
			drunkMathew (); //Check
		} else if (spellCombinations [0] == 1 && spellCombinations [1] == 3 && spellCombinations [2] == 2) {
			quakeState (); //Check
		} else if (spellCombinations [0] == 1 && spellCombinations [1] == 2 && spellCombinations [2] == 2) {
			psySpell ();
		}
		else
		{
			smokebomb();
		}
	}

	//Paralysis Spell
	void paralysis()
	{
		Debug.Log("Your Frozen Bitch");
		player.GetComponent<FirstPersonController>().enabled = false;
		isFrozen = true;
	}

	//Blind Spell - blindness is depend on the sky color
	void blindness()
	{
		isBlinded = !isBlinded;
		if (isBlinded)
		{
			isBlinded = true;
			Debug.Log("IM BLIND, BBBLLLLIIIIINNNDDDDD !!!!!!!");
			fpCamera.GetComponent<Camera>().cullingMask = (0);
		}
	}

	//Heart Spell
	void hearts()
	{
		heartActive = !heartActive;
		if (heartActive)
		{
			HeartParticles.SetActive(true);
			Debug.Log("GLORIOUS HEARTS!!!!");
		}
	}

	//Flashed Spell
	void Flashed()
	{
		flashBool = true;
		Debug.Log("FLASH !");
	}

	//Light Spell
	void light()
	{
		isAlight = !isAlight;
		if (isAlight)
		{
			selfLight.SetActive(true);
			Debug.Log("ILLUMINATION!!!!");
		}

	}

	//Scream Spell
	void Screaming()
	{
		

			GetComponent<AudioSource>().PlayOneShot(screaming);
			Debug.Log("AAAAAAAGGGGGGHHHHHHHHHHHH!!!!!!!!!!");


	}

	//smoke Spell
	void smokebomb()
	{
		smoke.SetActive (true);
	}

	//drunk Spell
	void drunkMathew()
	{
		

			fpCamera.GetComponent<MotionBlur>().enabled = true;


		/*if (fpCamera.GetComponent<MotionBlur>().enabled == true)
		{
			drunkTimer -= Time.deltaTime;
		}

		if (drunkTimer <= 0)
		{
			fpCamera.GetComponent<MotionBlur>().enabled = false;
			drunkTimer = 3;
		}*/
	}

	//Quake Spell
	void quakeState()
	{

			shake = 1;

		/*if (shake > 0)
		{
			fpCamera.transform.localPosition = Random.insideUnitSphere * shakeAmount;
			shake -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shake = 0;
		}*/
	}

	//Psy Spell
	void psySpell()
	{
		

			fpCamera.GetComponent<ColorCorrectionCurves>().enabled = true;


		/*if (fpCamera.GetComponent<ColorCorrectionCurves>().enabled == true)
		{
			psyLimit -= Time.deltaTime;
		}

		if (psyLimit <= 0)
		{
			fpCamera.GetComponent<ColorCorrectionCurves>().enabled = false;
			psyLimit = 5;
		}*/
	}

}