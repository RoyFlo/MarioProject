using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tcDropBomb : MonoBehaviour {

    public GameObject m_BulletObject;
    public Vector2 m_Offset;
    private float m_FireTime = 3.0f;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > this.m_FireTime)
        {
            this.m_FireTime = Time.time + (float)Random.Range(this.m_Offset.x, this.m_Offset.y);
            GameObject bulletClone = (GameObject)Instantiate(this.m_BulletObject, this.transform.position, this.transform.rotation);
        }
    }
}
    

