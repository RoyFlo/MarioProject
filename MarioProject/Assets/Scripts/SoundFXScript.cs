using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundFX {
    JUMP,
    BRICK_BREAK,
    COLLECT_COIN,
    COLLECT_MUSHROOM,
    COLLECT_STAR,
    COLLECT_1UP
}

public class SoundFXScript : MonoBehaviour {

    public AudioSource jumpSource;
    public AudioSource destroyBrickSource;
    public AudioSource coinSource;

    PlayerMove2 playerMove;

    /*
     * Needed sound effects:
     * Big mushroom
     * Star
     * 1-up
     */

   void Start() {

    }

	
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)) {
            jumpSource.Play();
        }
	}

    public void playFX(SoundFX soundFX) {
        switch (soundFX) {
            case SoundFX.JUMP:
                jumpSource.Play();
                break;
            case SoundFX.BRICK_BREAK:
                destroyBrickSource.Play();
                break;
            case SoundFX.COLLECT_COIN:
                coinSource.Play();
                break;
            case SoundFX.COLLECT_MUSHROOM:
            case SoundFX.COLLECT_STAR:
            case SoundFX.COLLECT_1UP:
                break;
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
    }
}
