using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death_respawn : MonoBehaviour {
    public AudioSource DeadPlumberJumping;
    //public GameObject respawn;
    public int respawn;
    public int DEAD;
    public bool hasDied;
    public int health;
    public GameObject Player;
    public bool bonus;
    public bool warped;
    public GameObject WarpZone;

    // Use this for initialization
    void Start() {
        health = ScoreKeeper.livesLeft;
        hasDied = false;
    }

    // Update is called once per frame
    // I can add in some stuff about the player health but I think jacky said he already had something with it
    void Update() {
        Player = GameObject.FindGameObjectWithTag("Player");
        warped = PipeWarp.warped;
        if (bonus == true) {
            warped = true;
            PipeWarp.warped = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player" && !hasDied) {
            Debug.Log("Death of the instant variety");
            hasDied = true;
            if (!gameObject.name.Contains("BonusExit")) {
                ScoreKeeper.isDead = true;
            }
            StartCoroutine("DIE");
        }

    }

    public IEnumerator DIE() {
        if (bonus == false) {
            health = health - 1;
            ScoreKeeper.livesLeft = health;
            Power_up.power_type = 0;
        }

        if (health >= 1) {
            if (!gameObject.name.Contains("BonusExit")) {
                SoundFXScript.playDeathSound();
                yield return new WaitForSeconds(3);
            }
            ScoreKeeper.resetTimer();
            Application.LoadLevel(respawn);
            yield return null;
        }
        if (health <= 0) {
            yield return new WaitForSeconds(3);
            Application.LoadLevel(DEAD);
            yield return null;
        }
    }
}
