using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeWarp : MonoBehaviour {

    public int load;


	// Use this for initialization
	void Start ()
    {

    }
	
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                Application.LoadLevel(load);
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
