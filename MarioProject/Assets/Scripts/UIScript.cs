using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Text worldTextField;
    public Text scoreTextField;
    public Text coinsCollectedTextField;
    public Text timeLeftTextField;

    private bool isPaused;

    private static BGMusicScript bgMusic;

    void Start() {
        bgMusic = FindObjectOfType<BGMusicScript>();
        ScoreKeeper.isFinished = false;
        StartCoroutine("LoseTime");
        isPaused = false;
    }

    IEnumerator LoseTime() {
        while (!isPaused) {
            yield return new WaitForSeconds(0.5f);
            ScoreKeeper.timeLeft--;
            if (ScoreKeeper.timeLeft == 100) {
                bgMusic.LowTime();
            }

            if (ScoreKeeper.timeLeft == 0) {
                ScoreKeeper.livesLeft -= 1;
                SoundFXScript.playDeathSound();
                yield return new WaitForSeconds(3);
                LevelManager.ReloadScene();
            }

            // Stops timer when player finishes level or dies
            if (ScoreKeeper.isFinished || ScoreKeeper.isDead) {
                ScoreKeeper.isFinished = false;
                ScoreKeeper.isDead = false;
                yield break;
            }
        }

        while (isPaused) {
            yield return null;
        }
    }

    void Update() {
        worldTextField.text = LoadLevelScript.topBarLevelName;
        scoreTextField.text = addToStartOfString(ScoreKeeper.score.ToString(), 6);
        coinsCollectedTextField.text = "x" + addToStartOfString(ScoreKeeper.coins.ToString(), 2);
        timeLeftTextField.text = addToStartOfString(ScoreKeeper.timeLeft.ToString(), 3);
    }

    private string addToStartOfString(string s, int digitCount) {
        return s.PadLeft(digitCount, '0');
    }
}
