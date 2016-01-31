using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class bookSceneControlScript : MonoBehaviour {

    public RawImage rawImg;
    public Texture[] pageImg;
    private int pageNumber;

	// Use this for initialization
	void Start () {

        pageNumber = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyUp(KeyCode.D))
        {
            nextPage();
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            lastPage();
        }

    }

    public void nextPage()
    {
        if(pageNumber < 6)
        { 
            pageNumber += 1;
            rawImg.texture = pageImg[pageNumber];
        }
        if(pageNumber == 6)
        {
            Application.LoadLevel("mainGameScene");
        }
    }
    
    public void lastPage()
    {
        if (pageNumber > 0)
        {
            pageNumber -= 1;
            rawImg.texture = pageImg[pageNumber];
        }
    }

}
