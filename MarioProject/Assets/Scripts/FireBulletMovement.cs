using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletMovement : MonoBehaviour {

    public Rigidbody2D bulletRB;
    public float speed;
    private float bulletTimer;
	// Use this for initialization
	void Start () {
        bulletRB.velocity = transform.right * speed * GameObject.Find("Fire Mario").transform.localScale.x;
        bulletTimer = 3;
	}
    private void Update()
    {
        if(bulletTimer > 0.0f)
        {
            bulletTimer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
