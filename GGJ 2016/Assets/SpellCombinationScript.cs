using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
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
    public float blindTimer = 4.0f;
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



	public GameObject flash;
	public GameObject scream;


	public AudioClip screaming;




	//public camera Camera;




	//private movement FirstPersonController;



	// Use this for initialization
	void Start () {
        HeartParticles.SetActive(false);



        selfLight.SetActive(false);

		
	}
	
	// Update is called once per frame
	void Update () {


		

		Flashed ();
		Screaming ();

		//paralysis ();
	


	if(Input.GetKeyDown(KeyCode.Alpha1))
    {
        if (spellsSelected < 3)
        {
            if (element1Active == false)
            {
                element1Active = true;
                int el1 = 1;
                spellCombinations.Add(el1);
                spellsSelected++;
            }
            else{
                Debug.Log("Spell Already Selected");
            }
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
            if (element2Active == false)
            {
                element2Active = true;
                int el2 = 2;
                spellCombinations.Add(el2);
                spellsSelected++;
            }
            else
            {
                Debug.Log("Spell Already Selected");
            }
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
            if (element3Active == false)
            {
                element3Active = true;
                int el3 = 3;
                spellCombinations.Add(el3);
                spellsSelected++;
            }
            else
            {
                Debug.Log("Spell Already Selected");
            }
        }
        else
        {
            Debug.Log("Spell Combinations Maxed");
        }
    }

        if(Input.GetMouseButtonDown(0))
        {
            if(element1Active == true && element2Active == true && element3Active == true)
            {
                element1Active = false;
                element2Active = false;
                element3Active = false;

                Debug.Log("Spell Cast" + spellCombinations[0].ToString() + spellCombinations[1].ToString() + spellCombinations[2].ToString());
                paralysis();
                blindness();
                hearts();
                light();
                Flashed();
                spellCombinations.Clear();
                spellsSelected = 0;
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

			
	}

	void paralysis ()
	{
		if (spellCombinations[0] == 2 && spellCombinations[1] == 1 && spellCombinations[2] == 3) 
		{
					Debug.Log ("Your Frozen Bitch");

					player.GetComponent<FirstPersonController> ().enabled = false;
                    isFrozen = true;


		}
	}

    void blindness()
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


            }


        }
    }

        void hearts ()
	{

        if (spellCombinations[0] == 2 && spellCombinations[1] == 3 && spellCombinations[2] == 1) 
		{
			heartActive = !heartActive;

			if (heartActive) {

                HeartParticles.SetActive(true);
				Debug.Log ("GLORIOUS HEARTS!!!!");


			} 

           
		

		}
	}


	void Flashed()
	{
        if (spellCombinations[0] == 3 && spellCombinations[1] == 1 && spellCombinations[2] == 2) 
		{
           
            flashBool = true;
			Debug.Log ("FLASH !");
		}
	}

    void light()
        {

            if (spellCombinations[0] == 1 && spellCombinations[1] == 2 && spellCombinations[2] == 3)
            {
                isAlight = !isAlight;

                if (isAlight)
                {

                    selfLight.SetActive(true);
                    Debug.Log("ILLUMINATION!!!!");


                }




            }
        }

	void Screaming()
	{
		if (Input.GetKeyDown (KeyCode.Q))
		{
			GetComponent<AudioSource> ().PlayOneShot (screaming);
			Debug.Log ("AAAAAAAGGGGGGHHHHHHHHHHHH!!!!!!!!!!");
		}
	}

}
