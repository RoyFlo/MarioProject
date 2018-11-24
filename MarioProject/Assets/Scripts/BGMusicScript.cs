using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour {

    public AudioSource bgMusicSource;
    public AudioSource lowTimeWarning;
    public AudioSource exitSceneMusic;
    public AudioSource starSource;

    void Start() {
        bgMusicSource.volume = 0.5f;
    }

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

    public IEnumerator playStarMusic() {
        bgMusicSource.Pause();
        starSource.Play();
        yield return null;
    }

    public void endStarMusic() {
        starSource.Stop();
        bgMusicSource.Play();
    }

    public void stopMusic() {
        bgMusicSource.Stop();
    }
}
