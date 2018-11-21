using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStuff : MonoBehaviour {

    public GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    void start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update ()
    {
       player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {
        player = GameObject.FindGameObjectWithTag("Player");

       float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
       float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
 
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
