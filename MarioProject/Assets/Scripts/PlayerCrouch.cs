using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour {

    public LayerMask ceiling;
    public Transform ceilingCheck;
    public float ceilingCheckRad;
    public bool touchedCeiling;
    public bool isCrouching;

    private void Update()
    {
        gameObject.GetComponent<Animator>().SetBool("isCrouching", isCrouching);
        gameObject.GetComponent<Animator>().SetBool("touchCeiling", touchedCeiling);

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            isCrouching = true;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            gameObject.transform.Find("GroundCheck").transform.localPosition = new Vector3(0, -0.1148f,0);
            gameObject.transform.Find("CeilingCheck").transform.localPosition = new Vector3(0.007f, 0.105f, 0);
        }
        else
        {
            isCrouching = false;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.transform.Find("GroundCheck").transform.localPosition = new Vector3(0, -0.154f, 0);
            gameObject.transform.Find("CeilingCheck").transform.localPosition = new Vector3(0.007f, 0.154f, 0);
        }
        
    }
    void FixedUpdate()
    {
        touchedCeiling = Physics2D.OverlapCircle(ceilingCheck.position, ceilingCheckRad, ceiling);
    }
}
