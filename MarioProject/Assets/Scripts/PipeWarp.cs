﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeWarp : MonoBehaviour {

    public int load;
    public GameObject player;
    public GameObject WarpZone;
    public static bool warped = false;

	// Use this for initialization
	void Start ()
    {
        if (warped == true)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            WarpZone = GameObject.FindGameObjectWithTag("Warp");

            player.transform.position = WarpZone.transform.position;
            warped = false;
        }
    }
	
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                warped = true;
                Application.LoadLevel(load);
                
            }
        }
    }

    //void OnLevelWasLoaded()
    //{
    //    if (warped == true)
    //    {
    //        player = GameObject.FindGameObjectWithTag("Player");
    //        WarpZone = GameObject.FindGameObjectWithTag("Warp");

    //        player.transform.position = WarpZone.transform.position;
    //        warped = false;
    //    }

    //}

    // Update is called once per frame
    void Update () {
		
	}

}
