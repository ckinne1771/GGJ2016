using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellCombinationScript : MonoBehaviour {

    List<int> spellCombinations = new List<int>();
    bool element1Active = false;
   
    bool element2Active = false;
   
    bool element3Active = false;
  
    bool maxSelection = false;
    int spellsSelected = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
            Debug.Log("Spell COmbinations Maxed");
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
            Debug.Log("Spell COmbinations Maxed");
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
            Debug.Log("Spell COmbinations Maxed");
        }
    }

        if(Input.GetKey(KeyCode.Space))
        {
            if(element1Active == true && element2Active == true && element3Active == true)
            {
                element1Active = false;
                element2Active = false;
                element3Active = false;

                Debug.Log("Spell Cast" + spellCombinations[0].ToString() + spellCombinations[1].ToString() + spellCombinations[2].ToString());
                spellCombinations.Clear();
                spellsSelected = 0;
            }
        }
	}
}
