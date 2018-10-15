using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public GameObject platform;
    public float moveSpeed;
    public Transform currPoint;
    public Transform[] points;
    public int pointSelect;


	// Use this for initialization
	void Start () {
        currPoint = points[pointSelect];
	}
	
	// Update is called once per frame
	void Update () {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currPoint.position, Time.deltaTime * moveSpeed);

        if (platform.transform.position == currPoint.position)
        {
            pointSelect++;
            if(pointSelect == points.Length)
            {
                pointSelect = 0;
            }

            currPoint = points[pointSelect];
        }
	}
}
