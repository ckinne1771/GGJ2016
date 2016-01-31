using UnityEngine;
using System.Collections;

public class ambStereoWindLoop : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip[] audioClip;
    private int clipSize = 2;
    private int cunt; //For switching index

    int whichCunt()
    {
        switch(cunt)
        {
            case 0:
                cunt = 1;
                break;
            case 1:
                cunt = 0;
                break;
        }

        return cunt;
    }

	// Use this for initialization
	void Start () {

        audioSource = GetComponent<AudioSource>();
        cunt = 0;
        audioSource.clip = audioClip[cunt];
        audioSource.Play();
        cunt++;

       
    }
	
	// Update is called once per frame
	void Update () {

       
        if (!audioSource.isPlaying)
        {
            whichCunt();
            audioSource.Play();
        }
	
        
	}
}
