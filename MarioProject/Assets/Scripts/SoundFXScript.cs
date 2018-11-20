using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXScript : MonoBehaviour {

    public AudioSource jumpSource;
    public AudioSource destroyBrickSource;
    public AudioSource coinSource;
    public AudioSource itemSource;
    public AudioSource growSource;

    public static bool isGrounded;

    void Start () {
        itemSource = GameObject.Find("ItemSource").GetComponent<AudioSource>();
        growSource = GameObject.Find("GrowSource").GetComponent<AudioSource>();
    }

    void Update () {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            jumpSource.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D trig) {
        if (trig.gameObject.tag == "DestroyBrick") {
            destroyBrickSource.Play();
            Destroy(trig.gameObject.transform.parent.gameObject);
            ScoreKeeper.addPoints(100);
        }

        if (trig.gameObject.tag == "HitQBlock") {
            coinSource.Play();
            trig.gameObject.tag = "QBlock";
            ScoreKeeper.addPoints(100);
            ScoreKeeper.addCoins(1);
        }

        if (trig.gameObject.name.Contains("Coin")) {
            coinSource.Play();
            ScoreKeeper.addPoints(100);
            ScoreKeeper.addCoins(1);
        }

        if (trig.gameObject.tag == "HitItemBlock") {
            itemSource.Play();
            trig.gameObject.tag = "QBlock";
        }

        if (trig.gameObject.name.Contains("Red Mushroom")) {
            growSource.Play();
            ScoreKeeper.addPoints(500);
        }
    }
}
