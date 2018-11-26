using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario_Die : MonoBehaviour {

    private float TimeCounter = 0.0f;
    private float aniTime = 1.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TimeCounter += Time.deltaTime;
        if (TimeCounter > aniTime)
        {
            Destroy(gameObject);
        }
    }
}
