using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseScript : MonoBehaviour {



    public GameObject buttonLayout;
    public GameObject playersControl;
    public bool showButton = false;

    // Use this for initialization
    void Start()
    {
        buttonLayout.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.P))
        {
            if (showButton == false)
            {
                //the button is showing
                Time.timeScale = 0;
                buttonLayout.SetActive(true);
                playersControl.GetComponent<FirstPersonController>().enabled = (false);
                Cursor.visible = true;

                showButton = true;

            }
            else
            {
                //the button is not showing
                Time.timeScale = 1;
                buttonLayout.SetActive(false);
                playersControl.GetComponent<FirstPersonController>().enabled = (true);
                Cursor.visible = false;

                showButton = false;

            }
        }
    }
}