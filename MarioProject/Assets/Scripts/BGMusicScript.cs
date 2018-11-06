using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour {

    public AudioSource bgMusicSource;
    public AudioSource lowTimeWarning;
    public AudioSource exitSceneMusic;

    void Awake() {
        bgMusicSource.Play();
    }

    public void ExitScene() {
        ScoreKeeper.isFinished = true;
        bgMusicSource.Stop();
        exitSceneMusic.Play();
    }

    public void LowTime() {
        bgMusicSource.Stop();
        lowTimeWarning.Play();
        bgMusicSource.pitch = 1.25f;
        bgMusicSource.PlayDelayed(3);
    }
}
