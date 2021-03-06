﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_up : MonoBehaviour {

    public static int power_type;
    public bool isInvincible;
    public float invincible_timer;

    public GameObject normal_mario;
    public GameObject big_mario;
    public GameObject fire_mario;
    public GameObject invincible_mario;
    public GameObject invincible_big_mario;

    public Death_respawn death;
    public GameObject Mario_Die;

    void OnLevelWasLoaded()
    {
        if(power_type == 1)
        {
            growBigger();
        }
        if(power_type == 2)
        {
            normal_mario.SetActive(false);
            fireUp();
        }
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
            invincible_timer = 12;
            RevertBackToNormalFromInvincible();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //check if collied with a power up and update the power type accordingly
        if(col.gameObject.tag == "Power Up")
        {
            if(col.gameObject.name.Contains("Coin"))
            {
                ScoreKeeper.addCoins(1);
                ScoreKeeper.addPoints(100);
            } else
                ScoreKeeper.addPoints(250);
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
                becomeInvincible();
            }
            //destroy the collectible, then get our power
            Destroy(col.gameObject);
        }
        //check if collided with enemy
        if (col.gameObject.tag == "Enemy")
        {
            // if we have a power up, we return to normal
            if(power_type > 0 && !isInvincible)
            {
                SoundFXScript.playShrinkSound();
                RevertBackToNormalAfterCollideWithEnemy();
                power_type = 0;

            }
            if (!isInvincible && power_type == 0 && !death.hasDied)
            {
                death.hasDied = true;
                ScoreKeeper.isDead = true;
                Destroy(gameObject);
                Instantiate(Mario_Die, transform.position, new Quaternion(0, 0, 0, 0));
                death.StartCoroutine(death.DIE());
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

        normal_mario.transform.position = oldMario.transform.position;
        oldMario.SetActive(false);
        normal_mario.SetActive(true);       
    }
}
