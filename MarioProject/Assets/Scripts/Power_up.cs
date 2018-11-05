using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_up : MonoBehaviour {

    public int power_type;
    private bool isInvincible;
    public float invincible_timer;

    public GameObject normal_mario;
    public GameObject big_mario;
    public GameObject fire_mario;
    public GameObject invincible_mario;
    public GameObject invincible_big_mario;

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
            RevertBackToNormalFromInvincible();
            invincible_timer = 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //check if collied with a power up and update the power type accordingly
        if(col.gameObject.tag == "Power Up")
        {
            if(col.gameObject.name.Contains("Red Mushroom") && power_type == 0)
            {
                power_type = 1;
                growBigger();
            }
            if (col.gameObject.name.Contains("Flower") && power_type == 1)
            {
                power_type = 2;
                fireUp();
            }
            // if we pick up a star, then we become invincible
            if(col.gameObject.name.Contains("Star"))
            {
                isInvincible = true;
                becomeInvincible();
            }
            //destroy the collectible, then get our power
            Destroy(col.gameObject);
        }
        //check if collided with enemy
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided with enemy and power_type is " + power_type);
            // if we are invincible, then the enemy die.
            if (isInvincible)
            {
                Destroy(col.gameObject);
            }
            // if we have a power up, we return to normal
            if(power_type > 0)
            {
                RevertBackToNormalAfterCollideWithEnemy();
                power_type = 0;

            }
        }
    }
    // use this to revert back from invincible state
    private void RevertBackToNormalFromInvincible()
    {
        GameObject oldMario = null;
        switch (power_type)
        {
            case 0: oldMario = normal_mario; break;
            case 1: oldMario = big_mario; break;
            case 2: oldMario = fire_mario; break;
        }
        oldMario.transform.position = this.gameObject.transform.position;
        oldMario.SetActive(true);
        gameObject.SetActive(false);
        isInvincible = false;
    }

    // use this to transition to invincible state
    private void becomeInvincible()
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
    }
    // use this to transition to big mario state
    private void growBigger()
    {
        big_mario.transform.position = normal_mario.transform.position;
        big_mario.SetActive(true);
        normal_mario.SetActive(false);
    }
    private void fireUp()
    {
        fire_mario.transform.position = big_mario.transform.position;
        fire_mario.SetActive(true);
        big_mario.SetActive(false);
    }
    private void RevertBackToNormalAfterCollideWithEnemy()
    {

        GameObject oldMario = null;
        switch (power_type)
        {
            case 1: oldMario = big_mario; break;
            case 2: oldMario = fire_mario; break;
        }
        Debug.Log("we were " + oldMario.name);
        normal_mario.transform.position = oldMario.transform.position;
        oldMario.SetActive(false);
        normal_mario.SetActive(true);       
    }
}
