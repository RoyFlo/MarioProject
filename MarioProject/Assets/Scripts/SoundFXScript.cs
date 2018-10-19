using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXScript : MonoBehaviour {

    public AudioSource jumpSource;
    public AudioSource destroyBrickSource;
    public AudioSource coinSource;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            jumpSource.Play();
        }
	}

    void OnTriggerEnter2D(Collider2D trig) {
        if (trig.gameObject.tag == "DestroyBrick") {
            destroyBrickSource.Play();
            Destroy(trig.gameObject.transform.parent.gameObject);
        }

        if (trig.gameObject.tag == "HitQBlock") {
            coinSource.Play();
            trig.gameObject.tag = "QBlock";
        }
    }
}
