using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement : MonoBehaviour {
    public float star_move_direction;
    public float star_move_speed;
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(star_move_direction,
            (gameObject.transform.position.x * 0.6f) + (star_move_direction * 0.01f)) * star_move_speed;
        if(gameObject.transform.position.y > 0.6f)
        {
            gameObject.GetComponent<StarMovement>().enabled = false;
        }
    }
}
