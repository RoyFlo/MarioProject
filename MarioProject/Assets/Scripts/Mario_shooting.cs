using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario_shooting : MonoBehaviour {
    public Transform firePoint;
    public GameObject fireBullet;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            shootBullet();
        }
	}
    public void shootBullet()
    {
        Instantiate(fireBullet, firePoint.position, Quaternion.identity);
    }
}
