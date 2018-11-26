using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletMovement : MonoBehaviour {

    public Rigidbody2D bulletRB;
    public float speed;
    public float bulletTimer;
	// Use this for initialization
	void Start () {
        bulletRB.velocity = transform.right * speed * GameObject.Find("Fire Mario").transform.localScale.x;
	}
    private void Update()
    {
        if (bulletTimer > 0)
        {
            bulletTimer -= Time.deltaTime;
        }
        else
            Destroy(gameObject);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy" || collision.transform.tag == "Goomba")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
