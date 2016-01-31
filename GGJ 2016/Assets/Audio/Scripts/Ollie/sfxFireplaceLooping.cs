using UnityEngine;
using System.Collections;

public class sfxFireplaceLooping : MonoBehaviour {


    public AudioSource audioSource;
    public AudioClip[] clipArray;
    public static bool b_FireIsOn;

    private int clipSize;
    private int indexMin = 0;
    private int indexMax;
    private int randomIndex;




	// Use this for initialization
	void Start ()
    {
        b_FireIsOn = true;
        audioSource = GetComponent<AudioSource>();
        indexMax = 7; //Number of sounds in clip
 
	
	}
	
	// Update is called once per frame
	void Update ()
    {
         randomIndex = Random.Range(indexMin, indexMax);


        //if (b_FireIsOn == true)
        // {
        if (!audioSource.isPlaying)
            {

                Debug.Log("RandomIndex: " + randomIndex);
            
                audioSource.clip = clipArray[randomIndex];
                audioSource.Play();
            }


      //  }

      //  else { audioSource.Stop(); }
	
	}
}
