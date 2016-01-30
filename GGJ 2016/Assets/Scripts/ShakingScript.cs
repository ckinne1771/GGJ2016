using UnityEngine;
using System.Collections;

public class ShakingScript : MonoBehaviour {

    public float shake = 0;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            shake = 1;
        }

        if (shake > 0)
        {
            this.transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
        }

        else
        {
            shake = 0;
        }
    }
}

