using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explo : MonoBehaviour {

    private float exploTime = 1.0f;
    private float timeCounter = 0.0f;
    public AudioClip exploSound;
    // Use this for initialization
    void Start () {
        GetComponent<AudioSource>().PlayOneShot(exploSound);
    }
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime;
        if (timeCounter > exploTime)
        {
            Destroy(gameObject);
        }
    }
}
