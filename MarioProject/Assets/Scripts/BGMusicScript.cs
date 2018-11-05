using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour {

    public AudioSource bgMusicSource;
    public AudioSource exitSceneMusic;

    void Awake() {
        bgMusicSource.Play();
    }

    public void ExitScene() {
        bgMusicSource.Stop();
        exitSceneMusic.Play();
    }
}
