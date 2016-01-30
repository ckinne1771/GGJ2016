using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
public class DrunkScript : MonoBehaviour {

    private float drunkTimer;
    public GameObject fpCamera;

    // Use this for initialization
    void Start()
    {
        drunkTimer = 3;
        fpCamera.GetComponent<MotionBlur>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("m"))
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
}