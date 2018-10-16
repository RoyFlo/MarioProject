using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Rigidbody2D myBody;
    public LayerMask enemyMask;
    Transform myTrans;
    float myWidth;
    public float speed = 1;

	void Start () {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
	}

    
    void FixedUpdate() {
        //Check if there is ground in front of the enemy
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
 //       bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2());
        //No ground, turn around
        if (!isGrounded)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }
        //Always move forward
        Vector2 myVelocity = myBody.velocity;
        myVelocity.x = -myTrans.right.x * speed;
        myBody.velocity = myVelocity;
	}
}
