using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBill : MonoBehaviour {

    // Use this for initialization
    Rigidbody2D myBody;
    Transform myTrans;
    public float speed = 1;
    public GameObject bullet;
    public GameObject player;
    public Death_respawn m_someOtherScriptOnAnotherGameObject;
    public Rigidbody2D bulletPrefab;

    void Start () {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        player = GameObject.FindGameObjectWithTag("Player");

     //   for (int i = 0; i < 20; i++)
     //   {
     //       ExecuteAfterTime(1);
     //   }
    }
    // Update is called once per frame
    void Update () {
        Vector2 myVelocity = myBody.velocity;
        myVelocity.x = myTrans.right.x * speed;
        myBody.velocity = myVelocity;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(bullet);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetType() == typeof(CircleCollider2D))
        {
            m_someOtherScriptOnAnotherGameObject.DIE();
        }
    }
}
