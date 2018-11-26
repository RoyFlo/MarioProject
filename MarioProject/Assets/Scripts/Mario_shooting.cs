using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario_shooting : MonoBehaviour {
    public Transform firePoint;
    public GameObject fireBullet;
    public float numberOfBullet;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(GameObject.FindGameObjectsWithTag("Bullet").Length < numberOfBullet)
                shootBullet();
        }
	}
    public void shootBullet()
    {
        GameObject bulletObject = Instantiate(fireBullet, firePoint.position, Quaternion.identity);
        bulletObject.tag = "Bullet";
    }
}
