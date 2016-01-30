using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class SpellCombinationScript : MonoBehaviour {

    List<int> spellCombinations = new List<int>();
    bool element1Active = false;
   
    bool element2Active = false;
   
    bool element3Active = false;
  
    bool maxSelection = false;
    int spellsSelected = 0;

	public GameObject player;

    public float freezeTimer = 3.0f;
    public float blindTimer = 2.0f;
    public float heartTimer = 5.0f;
    private bool isFrozen = false;
    private bool isAlight = false;
    public float lightTimer = 10.0f;

    public GameObject HeartParticles;
    public GameObject selfLight;
	public Camera cam;

    private bool heartActive = false;
	public bool isBlinded = false;

    private bool flashBool = false;

	public GameObject scream;

	public GameObject smoke;
	private bool smokeActive = false;

	public AudioClip screaming;

    public GameObject fpCamera;

    //Flashed Spell Update
    public BloomAndFlares BandF;
    public GameObject flash1stEffect;
    public float flash1stEffectTimer;

    //drunkMathew var.
    public float drunkTimer;

    //QuakeState var.
    public float shake = 0;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1;

	//Psy Spell
	public bool isPsy;
	public float psyLimit;


	//public camera Camera;
	//private movement FirstPersonController;

	// Use this for initialization
	void Start () {
        HeartParticles.SetActive(false);
		smoke.SetActive(false);

        selfLight.SetActive(false);
        
        //flashed Effect 1 setup
        flash1stEffect.SetActive(false);
        flash1stEffectTimer = 1;
        //flashed Effect 2 setup
        BandF = fpCamera.GetComponent<BloomAndFlares>();
        BandF.bloomIntensity = 0;

        //drunkMathew setup
        drunkTimer = 3;

        fpCamera.GetComponent<MotionBlur>().enabled = false;
		
		psyLimit = 5;
	}
	
	// Update is called once per frame
	void Update () {

	//Flashed ();
	Screaming ();
    drunkMathew();
    quakeState();
		psySpell ();
    //paralysis ();

    if(Input.GetKeyDown(KeyCode.Alpha1))
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

    if(Input.GetMouseButtonDown(0))
    {
        if(spellsSelected==3)
        {
              Debug.Log("Spell Cast" + spellCombinations[0].ToString() + spellCombinations[1].ToString() + spellCombinations[2].ToString());
                /*    paralysis();
                blindness();
                hearts();
                light();
                Flashed();*/

                if (paralysis() == false && blindness() == false && hearts() == false && light() == false && Flashed() == false)
                {
                    smokebomb();
                }
                
                spellCombinations.Clear();
                spellsSelected = 0;
            }
            else
            {
                Debug.Log("Not enough spells selected");
            }
        }

        if(isFrozen == true && freezeTimer >0)
        {
            freezeTimer-= Time.deltaTime;
            Debug.Log(freezeTimer.ToString());
        }
        else if( freezeTimer <= 0)
        {
            isFrozen = false;
            player.GetComponent<FirstPersonController>().enabled = true;
            freezeTimer = 3;
        }

        if (isBlinded == true && blindTimer > 0)
        {
            blindTimer -= Time.deltaTime;
            Debug.Log(blindTimer.ToString());
        }
        else if (blindTimer <= 0)
        {
            isBlinded = false;
            cam.cullingMask = (1);
            blindTimer = 4;
        }
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
        if (isAlight == true && lightTimer > 0)
        {
           lightTimer -= Time.deltaTime;
           // Debug.Log(blindTimer.ToString());
        }
        else if (lightTimer <= 0)
        {
            isAlight = false;
            selfLight.SetActive(false);
            lightTimer = 10;
        }

        //Flashed Spell Update
        if(flashBool == true && BandF.bloomIntensity == 0 )
        {
            flash1stEffect.SetActive(true);
            BandF.bloomIntensity = 100;
        }
        if (flashBool == true && BandF.bloomIntensity == 100)
        {
            flashBool = false;
        }

        if(flash1stEffect.active == true)
        {
            flash1stEffectTimer -= Time.deltaTime;
        }
        if(flash1stEffectTimer <= 0)
        {
            flash1stEffect.SetActive(false);
            flash1stEffectTimer = 1;
        }

        if(BandF.bloomIntensity > 0)
        {
            BandF.bloomIntensity -= 1;
        }
        if(BandF.bloomIntensity < 0)
        {
            BandF.bloomIntensity = 0;
        }
			
	}


	bool paralysis ()
	{
		if (spellCombinations[0] == 2 && spellCombinations[1] == 1 && spellCombinations[2] == 3) 
		{
					Debug.Log ("Your Frozen Bitch");

					player.GetComponent<FirstPersonController> ().enabled = false;
                    isFrozen = true;
                    return true;

		}
        else
        {
            return false;
        }
	}

    //blindness is depend on the sky color
    bool blindness()
    {

        if (spellCombinations[0] == 3 && spellCombinations[1] == 2 && spellCombinations[2] == 1)
        {
            isBlinded = !isBlinded;

            if (isBlinded)
            {

                isBlinded = true;
                Debug.Log("IM BLIND, BBBLLLLIIIIINNNDDDDD !!!!!!!");

                //camera = GetComponentsInChildren<Camera>();
                //cam = GetComponent<Camera>().cullingMask = 0;
                //cam = GetComponent<Camera>().enabled = false;
                cam.cullingMask = (0);
                return true;

            }
            else
            {
                return false;
            }
        }
            else
            {
                return false;
            }

        }
    

    bool hearts ()
	{

        if (spellCombinations[0] == 2 && spellCombinations[1] == 3 && spellCombinations[2] == 1) 
		{
			heartActive = !heartActive;

			if (heartActive) {

                HeartParticles.SetActive(true);
				Debug.Log ("GLORIOUS HEARTS!!!!");
                return true;

			}
            else
            {
                return false;
            }

		}
else
        {
            return false;
        }

	}

    //Flashed Spell
	bool Flashed()
	{
        if (spellCombinations[0] == 3 && spellCombinations[1] == 1 && spellCombinations[2] == 2) 
		{
            flashBool = true;
			Debug.Log ("FLASH !");
            return true;
		}
        else
        {
            return false;
        }
	}

    bool light()
        {

            if (spellCombinations[0] == 1 && spellCombinations[1] == 2 && spellCombinations[2] == 3)
            {
                isAlight = !isAlight;

                if (isAlight)
                {

                    selfLight.SetActive(true);
                    Debug.Log("ILLUMINATION!!!!");
                    return true;

                }
                else
                {
                    return false;
                }


            }
else
            {
                return false;
            }
        }

	bool Screaming()
	{
		if (Input.GetKeyDown (KeyCode.Q))
		{
			GetComponent<AudioSource> ().PlayOneShot (screaming);
			Debug.Log ("AAAAAAAGGGGGGHHHHHHHHHHHH!!!!!!!!!!");
            return true;
		}
        else
        {
            return false;
        }
	}

	void smokebomb()
	{
		
			smokeActive = !smokeActive;

			if (smokeActive) {

				smoke.SetActive(true);
				Debug.Log ("Puff");

			}
		}
		
	void drunkMathew()
    {
        //if (spellCombinations[0] == 1 && spellCombinations[1] == 2 && spellCombinations[2] == 3)
        //testing code
        if(Input.GetKeyDown(KeyCode.R))
        {
             fpCamera.GetComponent<MotionBlur>().enabled = true;
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
    }

    void quakeState()
    {
        //if (spellCombinations[0] == 1 && spellCombinations[1] == 2 && spellCombinations[2] == 3)
        if (Input.GetKeyDown(KeyCode.T))
        {
            shake = 1;
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
    }

	void psySpell()
	{
		/*if(Input.GetKeyDown(KeyCode.L))
			{
			fpCamera.GetComponent<ColorCorrectionCurves> ().enabled = true;
			

	
			}*/

		if(Input.GetKeyDown(KeyCode.L))
		{
			fpCamera.GetComponent<ColorCorrectionCurves>().enabled = true;
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
	
	}

}
