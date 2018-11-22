using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletMovement : MonoBehaviour {

    public Rigidbody2D bulletRB;
    public float speed;
	// Use this for initialization
	void Start () {
        bulletRB.velocity = transform.right * speed * GameObject.Find("Fire Mario").gameObject.transform.localScale.x;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with " + collision.transform.name);
    }
}
