using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillSpawn : MonoBehaviour {
    public GameObject bulletBill;
    public Transform launcher;

    public float LocateTime = 0;
    public float LocateNeedTime = 3;
    public float ShootingTime = 1.0f;
    public float ShootingNeedTime = 1.0f;


    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AITime();
        SpawnObject();
    }

    void AITime()
    {
        if (LocateTime <= 0)  //if LocateTime <= 0
        {
            LocateTime = LocateNeedTime;  //set LocateTime to LocateNeedTime
        }
        else //
        {
            LocateTime -= Time.deltaTime;
        }
    }

    public void SpawnObject()
    {
        if (ShootingTime <= 0)  //ShootingTime <= 0
        {
            ShootingTime = ShootingNeedTime;
            Instantiate(bulletBill, launcher.position, Quaternion.identity);
        }
        else
        {
            ShootingTime -= Time.deltaTime;
        }
        
    }

    
}
