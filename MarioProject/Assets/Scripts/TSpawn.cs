using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSpawn : MonoBehaviour {

    public float spawnTime;        // The amount of time between each spawn.
    public float spawnDelay;       // The amount of time before spawning starts.
    public GameObject bulletBill;
    public Vector3 originalPos;
    public GameObject bulletBlaster;

    void Start()
    {   
        bulletBlaster = GameObject.FindGameObjectWithTag("Bullet Blaster");
        originalPos = bulletBlaster.transform.position;
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }
    public void SpawnObject()
    {
        transform.eulerAngles = new Vector3(0, -180, 0);
        Instantiate(bulletBill, originalPos, transform.rotation);
    }
}

