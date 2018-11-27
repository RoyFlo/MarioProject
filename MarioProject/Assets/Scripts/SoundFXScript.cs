using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundFXScript : MonoBehaviour {

    public static AudioSource jumpSource;
    public static AudioSource destroyBrickSource;
    public static AudioSource coinSource;
    public static AudioSource itemSource;
    public static AudioSource growSource;
    public static AudioSource deathSource;
    public static AudioSource oneUpSource;
    public static AudioSource warpSource;

    public static bool isGrounded;

    private static BGMusicScript bgMusic;

    void Start() {
        jumpSource = GameObject.Find("JumpSource").GetComponent<AudioSource>();
        destroyBrickSource = GameObject.Find("DestroyBrickSource").GetComponent<AudioSource>();
        coinSource = GameObject.Find("CoinSource").GetComponent<AudioSource>();
        itemSource = GameObject.Find("ItemSource").GetComponent<AudioSource>();
        growSource = GameObject.Find("GrowSource").GetComponent<AudioSource>();
        deathSource = GameObject.Find("DeathSource").GetComponent<AudioSource>();
        oneUpSource = GameObject.Find("OneUpSource").GetComponent<AudioSource>();
        warpSource = GameObject.Find("WarpSource").GetComponent<AudioSource>();

        bgMusic = FindObjectOfType<BGMusicScript>();

        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        if (isGrounded && 
            Input.GetKeyDown(KeyCode.Space) && 
            SceneManager.GetActiveScene().buildIndex != 0 &&
            SceneManager.GetActiveScene().buildIndex != 10 &&
            SceneManager.GetActiveScene().buildIndex != 11) 
        {
            jumpSource.Play();
        }
    }

    IEnumerator OnTriggerEnter2D(Collider2D trig) {
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
        }

        if (trig.gameObject.tag == "HitItemBlock") {
            itemSource.Play();
            trig.gameObject.tag = "QBlock";
        }

        if (trig.gameObject.name.Contains("Red Mushroom")) {
            growSource.Play();
            ScoreKeeper.addPoints(500);
        }

        if (trig.gameObject.name.Contains("Star")) {
            yield return StartCoroutine(bgMusic.playStarMusic());
            yield return new WaitForSeconds(12);
            bgMusic.endStarMusic();
        }

        /*
        if (trig.gameObject.name.Contains("DeathStuff") || trig.gameObject.name.Contains("goombaBody")) {
            playDeathSound();
            yield return new WaitForSeconds(3);
        }
        */

        if (trig.gameObject.name.Contains("BonusExit")) {
            Warp();
        }
    }

    void OnTriggerStay2D(Collider2D trig) {
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && trig.gameObject.name.Contains("WarpPipe")) {
            Warp();
        }
    }

    public static void playDeathSound() {
        bgMusic.stopMusic();
        deathSource.Play();
    }

    public static void OneUp() {
        oneUpSource.Play();
    }

    public static void Warp() {
        warpSource.Play();
    }
}
