using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMovement : MonoBehaviour {
    public float mushroom_move_direction;
    public float mushroom_move_speed;
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(mushroom_move_direction, 0) * mushroom_move_speed;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pipe")
        {
            mushroom_move_direction *= -1;
        }
    }
}
