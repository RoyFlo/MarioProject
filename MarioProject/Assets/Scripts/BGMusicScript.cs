using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour {

    public AudioSource bgMusicSource;
    public AudioSource exitSceneMusicSource;

    void Awake() {
        bgMusicSource.Play();
    }

    public void ExitScene() {
        bgMusicSource.Stop();
        exitSceneMusicSource.Play();
    }
}
