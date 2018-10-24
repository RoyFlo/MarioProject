using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_up : MonoBehaviour {

    public int power_type;
    private int previous_power;
    private bool isInvincible;
    public float invincible_timer;

    public GameObject normal_mario;
    public GameObject big_mario;
    public GameObject fire_mario;
    public GameObject invincible_mario;
    public GameObject invincible_big_mario;

	void Start () {
        power_type = 0;
        previous_power = power_type;
        invincible_timer = 10;
	}
	
	// Update is called once per frame
	void Update () {
        // if we are invincible, then we count down the invincible timer
        if(isInvincible == true)
        {
            invincible_timer -= Time.deltaTime;

        }
        // when invincible time out, we return to normal, and reset the invincible timer.
        if(invincible_timer < 0.0f)
        {
            isInvincible = false;
            getPower();
            invincible_timer = 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //check if collied with a power up and update the power type accordingly
        if(col.gameObject.tag == "Power Up")
        {
            if(col.gameObject.name.Contains("Red Mushroom"))
            {
                power_type = 1;
            }
            if (col.gameObject.name.Contains("Flower") && power_type == 1)
            {
                power_type = 2;
            }
            // if we pick up a star, then we become invincible
            if(col.gameObject.name.Contains("Star"))
            {
                isInvincible = true;
            }
            //update previous power and destroy the collectible, then get our power
            previous_power = power_type;
            Destroy(col.gameObject);
            getPower();
        }
        //check if collided with enemy
        if (col.gameObject.tag == "Enemy")
        {
            // if we are invincible, then the enemy die.
            if (isInvincible)
            {
                Destroy(col.gameObject);
            }
            // if we have a power up, we return to normal
            if(power_type != 0)
            {
                power_type = 0;
                getPower();
            }
        }
    }
    // we use different object to power up.
    private void getPower()
    {
        // invincible power
        if (isInvincible)
        {
            if(power_type == 0)
            {
                invincible_mario.transform.position = normal_mario.transform.position;
                normal_mario.SetActive(false);
                invincible_mario.SetActive(true);
            }
            if(power_type == 1)
            {
                invincible_big_mario.transform.position = big_mario.transform.position;
                big_mario.SetActive(false);
                invincible_big_mario.SetActive(true);
            }
            if(power_type == 2)
            {
                invincible_big_mario.transform.position = fire_mario.transform.position;
                fire_mario.SetActive(false);
                invincible_big_mario.SetActive(true);
            }
        } // return to normal 
        else if(power_type == 0)
        {
            if (previous_power == 1)
            {
                normal_mario.transform.position = big_mario.transform.position;
                big_mario.SetActive(false);
            }
            if(previous_power == 2)
            {
                normal_mario.transform.position = fire_mario.transform.position;
                fire_mario.SetActive(false);
            }

            normal_mario.SetActive(true);
        } // turn into a big mario
        if(power_type == 1)
        {
            big_mario.transform.position = normal_mario.transform.position;
            big_mario.SetActive(true);
            normal_mario.SetActive(false);
        } // big mario turn into fire mario
        if(power_type == 2)
        {
            fire_mario.transform.position = big_mario.transform.position;
            fire_mario.SetActive(true);
            big_mario.SetActive(false);
        }
        //update previous power;
        previous_power = power_type;
    }
}
