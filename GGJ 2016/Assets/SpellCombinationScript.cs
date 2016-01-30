using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class SpellCombinationScript : MonoBehaviour {

    List<int> spellCombinations = new List<int>();
    bool element1Active = false;
   
    bool element2Active = false;
   
    bool element3Active = false;
  
    bool maxSelection = false;
    int spellsSelected = 0;

	public GameObject player;

    public float freezeTimer = 3.0f;
    private bool isFrozen = false;


	public Camera cam;
	public bool isFrozen = false;
	public bool isBlinded = false;



	//public camera Camera;




	//private movement FirstPersonController;



	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {


		paralysis ();
		blindness ();


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

	void blindness ()
	{

		if (Input.GetButtonDown ("Fire1")) 
		{
			isBlinded = !isBlinded;

			if (isBlinded) {

				isBlinded = true;
				Debug.Log ("IM BLIND, BBBLLLLIIIIINNNDDDDD !!!!!!!");

				//camera = GetComponentsInChildren<Camera>();
				//cam = GetComponent<Camera>().cullingMask = 0;
				//cam = GetComponent<Camera>().enabled = false;
			


			} 
			else 
			{
				isBlinded = false;
				//cam = GetComponent<Camera>().cullingMask = "Everything";
				//cam = GetComponent<Camera>().enabled = true;


			}


		}
	}
}
