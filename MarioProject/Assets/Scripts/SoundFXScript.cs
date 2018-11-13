using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundFXScript : MonoBehaviour {

    public AudioSource jumpSource;
    public AudioSource destroyBrickSource;
    public AudioSource coinSource;
    public AudioSource itemSource;
    public AudioSource growSource;
    public AudioSource warpSource;

    private CircleCollider2D warpPipe;

    BGMusicScript bgMusic;

    public static bool grounded;

    void Start() {
        bgMusic = FindObjectOfType<BGMusicScript>();
        if (GameObject.Find("warpPipe").GetComponent<CircleCollider2D>() == null) {
            warpPipe = new CircleCollider2D();
            Debug.Log("No warp pipe");
        } else {
            warpPipe = GameObject.Find("warpPipe").GetComponent<CircleCollider2D>();
        }
    }

    void Update() {
        if (grounded && Input.GetKeyDown(KeyCode.Space)) {
            jumpSource.Play();
        }
	}

    void OnTriggerEnter2D(Collider2D trig) {
        if (trig.gameObject.tag == "DestroyBrick") {
            ScoreKeeper.addPoints(100);
            destroyBrickSource.Play();
            Destroy(trig.gameObject.transform.parent.gameObject);
        }

        if (trig.gameObject.tag == "HitQBlock") {
            ScoreKeeper.addPoints(500);
            ScoreKeeper.addCoins(1);
            coinSource.Play();
            trig.gameObject.tag = "QBlock";
        }

        if(trig.gameObject.tag == "Power Up") {
            ScoreKeeper.addPoints(500);
            ScoreKeeper.addCoins(1);
            coinSource.Play();
        }

        if (trig.gameObject.tag == "HitItemBlock") {
            ScoreKeeper.addPoints(100);
            itemSource.Play();
            trig.gameObject.tag = "QBlock";
        }

        if (trig.gameObject.name.Contains("Star")) {
            bgMusic.playStarMusic();
        }

        if (trig.gameObject.name.Contains("Red Mushroom")) {
            growSource.Play();
        }        
    }

    IEnumerator OnTriggerStay2D(Collider2D trig) {
        if (trig.GetComponent<CircleCollider2D>() == warpPipe && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))) {
            warpSource.Play();
            yield return new WaitForSeconds(1.5f);
        }
    }
}
