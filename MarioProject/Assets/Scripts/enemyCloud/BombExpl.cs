using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExpl : MonoBehaviour {

    public float BombSpeed;
    public float BombLife;
    private float lifeCounter = 0.0f;
    public GameObject explos;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lifeCounter += Time.deltaTime;
        if (lifeCounter > BombLife)
        {
            Destroy(gameObject);
            Instantiate(explos, transform.position, new Quaternion(0, 0, 0, 0));
        }
    }
}
