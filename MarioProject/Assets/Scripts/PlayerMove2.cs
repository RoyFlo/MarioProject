using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour {

    private Rigidbody2D m_RigidBody;
    private Animator m_Animator;

    public float moveSpeed;
    public float jumpHeight;
    public float moveVel = 0f;

    public Transform groundCheck;
    public float groundCheckRad;
    public LayerMask ground;
    public bool grounded;


	// Use this for initialization
	void Start ()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_Animator.SetFloat("Speed", Mathf.Abs(m_RigidBody.velocity.x));
        m_Animator.SetBool("Grounded", grounded);


        //jump
        if (Input.GetKeyDown (KeyCode.Space) && grounded)
        {
            m_RigidBody.velocity = new Vector2(m_RigidBody.velocity.x, jumpHeight);
        }
        moveVel = 0f;
        //move Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //m_RigidBody.velocity = new Vector2(moveSpeed, m_RigidBody.velocity.y);
            moveVel = moveSpeed;
        }

        //move Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //m_RigidBody.velocity = new Vector2(-moveSpeed, m_RigidBody.velocity.y);
            moveVel = -moveSpeed;
        }

        m_RigidBody.velocity = new Vector2(moveVel, m_RigidBody.velocity.y);

        //flips player
        if (m_RigidBody.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (m_RigidBody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }


    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRad, ground);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
