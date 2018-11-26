using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Rigidbody2D myBody;
    public LayerMask enemyMask;
    Transform myTrans;
    float myWidth;
    public float speed = 1;
    private bool moveRight = true;
    public GameObject koopa;
    public GameObject player;
    public Death_respawn m_someOtherScriptOnAnotherGameObject;

    void Start () {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
        koopa = GameObject.FindGameObjectWithTag("Koopa");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(koopa);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetType() == typeof(CircleCollider2D))
        {
            m_someOtherScriptOnAnotherGameObject.DIE();
            Destroy(player);
        }
     //   if (collision.collider.GetType() == typeof(BoxCollider2D))
     //   {
     //      m_someOtherScriptOnAnotherGameObject.DIE();
     //       Destroy(player);
     //   }
    }

    void FixedUpdate() {
     //   RaycastHit2D groundInfo = Physics2D.Raycast(myTrans.position, Vector2.up, 2f);
        //Check if there is ground in front of the enemy
     //   Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
     //   Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
     //   bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
        //       bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2());
        //No ground, turn around
        //       if (!isGrounded)
        //       {
        //           Vector3 currRot = myTrans.eulerAngles;
        //           currRot.y += 180;
        //           myTrans.eulerAngles = currRot;
        //       }
        //Always move forward
        Vector2 myVelocity = myBody.velocity;
        myVelocity.x = -myTrans.right.x * speed;
        myBody.velocity = myVelocity;
     //   if (groundInfo.collider == false)
     //   {
     //       if(moveRight == true)
     //       {
     //           transform.eulerAngles = new Vector3(0, -180, 0);
     //           moveRight = false;
     //       }
     //       else
     //      {
     //           transform.eulerAngles = new Vector3(0, 0, 0);
     //           moveRight = true;
     //       }
     //   }
	}
}
