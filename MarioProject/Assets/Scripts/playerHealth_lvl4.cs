using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Playerhealth_lvl4 : MonoBehaviour
{

    public AudioSource DeadPlumberJumping;

    public bool hasDied;

    // I'm going to decide on max health and stuff later
    public int health;

    // Use this for initialization
    void Start()
    {
        health = 1;
        hasDied = false;
    }

    // Update is called once per frame
    // I can add in some stuff about the player health but I think jacky said he already had something with it
    void Update()
    {
        if (gameObject.transform.position.y < -1.7)
        {
            Debug.Log("Player has died");
            hasDied = true;
        }
        if (hasDied == true)
        {
            // May need to deactivate camera script and start death animation
            Debug.Log("Death of the instant variety");
            StartCoroutine("Die");
        }
        if (health <= 0)
        {
            Debug.Log("Player is out of health, YOU'RE DEAD!!!");
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        // Reloads the level after the Die subroutine is called, Mario will automatically spawn in after 1 second
        // In future maybe load in a check for lives and other shit 
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Lvl4");
        yield return null;
        /* 
        Debug.Log("Player has fallen");
        yield return new WaitForSeconds(2);
        Debug.Log("Player has died");
        */
    }
}
