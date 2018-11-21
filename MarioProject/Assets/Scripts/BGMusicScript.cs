using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour {

    public static AudioSource lowTimeWarning;
    public static AudioSource starSource;

    public AudioSource bgMusicSource;
    public AudioSource exitSceneMusic;

    void Start() {
        lowTimeWarning = GameObject.Find("LowTimeSource").GetComponent<AudioSource>();
        starSource = GameObject.Find("StarSource").GetComponent<AudioSource>();

        bgMusicSource.volume = 0.5f;

        DontDestroyOnLoad(this.gameObject);
    }

    void OnLevelWasLoaded() {
        bgMusicSource = GameObject.Find("BGMusicSource").GetComponent<AudioSource>();
        exitSceneMusic = GameObject.Find("ExitSource").GetComponent<AudioSource>();
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
        yield return new WaitForSeconds(10);
        bgMusicSource.Play();
    }
}
