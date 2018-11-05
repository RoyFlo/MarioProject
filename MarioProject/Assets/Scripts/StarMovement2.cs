using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement2 : MonoBehaviour {
    public float timeOut;
    public float topScreen;
    public float bottomScreen;
	void Update () {
		if(gameObject.transform.position.y < bottomScreen)
        {
            Destroy(gameObject);
        }
        if(gameObject.transform.position.y > topScreen)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player"  || collision.gameObject.tag != "Enemy")
        {
            gameObject.GetComponent<StarMovement>().enabled = true;
            gameObject.GetComponent<StarMovement>().star_move_direction *= -1.015f;
        }
    }

    private void FixedUpdate()
    {
        if (timeOut > 0)
        {
            timeOut -= Time.deltaTime;
        }
        else
            Destroy(gameObject);
    }
}
