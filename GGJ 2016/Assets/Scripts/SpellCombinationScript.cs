using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;
using System;

public class SpellCombinationScript : MonoBehaviour
{

    public GameObject fpCamera;

    List<int> spellCombinations = new List<int>();

    bool element1Active = false;
    bool element2Active = false;
    bool element3Active = false;

	public float randomNum;

    bool maxSelection = false;

    int spellsSelected = 0;

    public GameObject player;

    public float freezeTimer = 3.0f;
    private bool isFrozen = false;
    public bool isAlight = false;

    public PauseScript pauseGame;

    //Heart Spell
    public GameObject HeartParticles;
    public float heartTimer = 5.0f;
    public bool heartActive = false;
	public AudioClip heartSound;

    //Light Spell
    public float lightTimer = 10.0f;
    public GameObject selfLight;
	//public bool lightActive = false;

    //Blind Spell
    public float blindTimer = 2.0f;
    public bool isBlinded = false;

    //Scream Spell
    public GameObject scream;
    public AudioClip screaming;
    //Scream Spell + 
    private bool screamDamage;
    private Collider coll;

    //Smoke Spell
    public GameObject smoke;
    //private bool smokeActive = false;
    public float pooTimer = 2;

    //Flashed Spell Update
    public BloomAndFlares BandF;
    public GameObject flash1stEffect;
    public float flash1stEffectTimer;
	public bool flashBool = false;
	public AudioClip flashSound;

    //drunkMathew var.
    public float drunkTimer;

    //QuakeState var.
    public float shake = 0;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1;
	public AudioClip quakeSound;

    //Psy Spell
	public GameObject soundObj;
    public bool isPsy;
    public float psyLimit;
	public AudioClip psysound;
	public AudioClip spellSound;


	public InteractScript interactRune;

    //Spell Compelete
    private int castingLV;

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
		//randomNumber ();
		if (pauseGame.showButton == false) {
			//Making Spell
			if (interactRune.Rune1.active == true) {
				if (Input.GetKeyDown (KeyCode.Alpha1)) {
					if (spellsSelected < 3) {
						int el1 = 1;
						spellCombinations.Add (el1);
						spellsSelected++;
					} else {
						Debug.Log ("Spell Combinations Maxed");
					}
				}
			} else {
			}
		}
		if (interactRune.Rune2.active == true) {
			
				if (Input.GetKeyDown (KeyCode.Alpha2)) {
					if (spellsSelected < 3) {
						int el2 = 2;
						spellCombinations.Add (el2);
						spellsSelected++;
					} else {
						Debug.Log ("Spell Combinations Maxed");
					}
				}
			else {
			}
		}  

		if (interactRune.Rune3.active == true) {

			if (Input.GetKeyDown (KeyCode.Alpha3)) {
				if (spellsSelected < 3) {
					int el3 = 3;
					spellCombinations.Add (el3);
					spellsSelected++;
				} else {
					Debug.Log ("Spell Combinations Maxed");
				}
			} else {
			}
		}

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
            fpCamera.GetComponent<Camera>().cullingMask = (-1);
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

        //psy Spell Eff.
        if (psyLimit <= 0)
        {
            fpCamera.GetComponent<ColorCorrectionCurves>().enabled = false;
            psyLimit = 5;
        }

        //shake Spell Eff.
        if (shake > 0)
        {
            fpCamera.transform.localPosition = UnityEngine.Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0;
        }

        //drunkMathew Spell Eff.
        if (fpCamera.GetComponent<MotionBlur>().enabled == true)
        {
            drunkTimer -= Time.deltaTime;
        }

        if (drunkTimer <= 0)
        {
            fpCamera.GetComponent<MotionBlur>().enabled = false;
            drunkTimer = 3;
        }

        //smoke Spell Eff.
        if (smoke.active == true) {
            pooTimer -= Time.deltaTime;
        }

        if (pooTimer <= 0)
        {
            smoke.SetActive(false);
            pooTimer = 2;
        }

        //Screaming Spell Eff.+
        if (screamDamage == true && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            screamDamage = false;
            if (Physics.Raycast(ray,out hit))
            {
                if(hit.collider.gameObject.layer == 8)
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }

        //casting spell
        if (Input.GetKeyDown(KeyCode.C))
        {
            castingLV = 1;
        }
        if (castingLV == 1 && Input.GetKeyDown(KeyCode.H))
        {
            castingLV = 2;
        }
        if (castingLV == 2 && Input.GetKeyDown(KeyCode.R))
        {
            castingLV = 3;
        }
        if (castingLV == 3 && Input.GetKeyDown(KeyCode.I))
        {
            castingLV = 4;
        }
        if (castingLV == 4 && Input.GetKeyDown(KeyCode.S))
        {
            castingLV = 5;
        }

        if (castingLV == 5)
        {
            Debug.Log("Unlimited Power!!!");
            otherSpell();
            if(castingLV == 5 && Input.GetKeyDown(KeyCode.Escape))
            { castingLV = 6; }
        }

    }



    //SpellBook List
    void castASpell()
    {

        //Paralysis Spell
        if (spellCombinations[0] == 2 && spellCombinations[1] == 3 && spellCombinations[2] == 1) {
            paralysis();
        } else if (spellCombinations[0] == 3 && spellCombinations[1] == 3 && spellCombinations[2] == 2) {
            blindness();
        } else if (spellCombinations[0] == 1 && spellCombinations[1] == 1 && spellCombinations[2] == 2) {
            hearts();
        } else if (spellCombinations[0] == 1 && spellCombinations[1] == 1 && spellCombinations[2] == 3) {
            Flashed();
        } else if (spellCombinations[0] == 3 && spellCombinations[1] == 2 && spellCombinations[2] == 3) {
            light();
        } else if (spellCombinations[0] == 2 && spellCombinations[1] == 1 && spellCombinations[2] == 3) {
            Screaming(); //Check
        } else if (spellCombinations[0] == 1 && spellCombinations[1] == 2 && spellCombinations[2] == 1) {
            drunkMathew(); //Check
        } else if (spellCombinations[0] == 1 && spellCombinations[1] == 1 && spellCombinations[2] == 1) {
            quakeState(); //Check
        } else if (spellCombinations[0] == 3 && spellCombinations[1] == 1 && spellCombinations[2] == 2) {
            psySpell();
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
			GetComponent<AudioSource> ().PlayOneShot (heartSound);

        }
    }

    //Flashed Spell
    void Flashed()
    {
        flashBool = true;
        Debug.Log("FLASH !");
		GetComponent<AudioSource> ().PlayOneShot (flashSound);
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
        screamDamage = true;
        GetComponent<AudioSource>().PlayOneShot(screaming);
        Debug.Log("AAAAAAAGGGGGGHHHHHHHHHHHH!!!!!!!!!!");
    }

    //smoke Spell
    void smokebomb()
    {
        smoke.SetActive(true);
    }

    //drunk Spell
    void drunkMathew()
    {
        fpCamera.GetComponent<MotionBlur>().enabled = true;

    }

    //Quake Spell
    void quakeState()
    {
        shake = 1;
		GetComponent<AudioSource> ().PlayOneShot (quakeSound);
    }

    //Psy Spell
    void psySpell()
    {
        fpCamera.GetComponent<ColorCorrectionCurves>().enabled = true;
		GetComponent<AudioSource> ().PlayOneShot (psysound);

    }

    //other Spell?
    void otherSpell()
    {
		soundObj.GetComponent<AudioSource> ().PlayOneShot (spellSound);

        drunkMathew();
        quakeState();
        psySpell();
    }

	void randomNumber()

	{
		

	}


}