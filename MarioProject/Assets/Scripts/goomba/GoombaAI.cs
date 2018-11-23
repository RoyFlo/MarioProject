using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaAI : MonoBehaviour {

    public float speed = 0.5f;
    public Transform Player;
    public GameObject deathAnim;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;
        if (Vector2.Distance(Player.position, transform.position) < 2.0f)
        {
            transform.position += (displacement * speed * Time.deltaTime);

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(deathAnim, transform.position, Quaternion.Euler(0, 0, 0));
        }
        /*
        if (col.tag == "Player")
        {
            Destroy(col.gameObject);
            //Destroy(gameObject);
        }
        */
    }
}


