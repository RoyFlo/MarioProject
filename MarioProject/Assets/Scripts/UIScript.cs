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

    BGMusicScript bgMusic;

    void Start() {
        bgMusic = FindObjectOfType<BGMusicScript>();
        ScoreKeeper.timeLeft = 999;
        ScoreKeeper.isFinished = false;
        StartCoroutine("LoseTime");
        isPaused = false;
    }
    
    IEnumerator LoseTime() {
        while (!isPaused) {
            yield return new WaitForSeconds(0.5f);
            ScoreKeeper.timeLeft--;
            if (ScoreKeeper.timeLeft == 150) {
                bgMusic.LowTime();
            }

            if(ScoreKeeper.timeLeft == 0) {
                // End game
            }

            // How to stop timer when player finishes level
            if(ScoreKeeper.isFinished) {
                yield break;
            }
        }

        while (isPaused) {
            yield return null;
        }
    }

    void Update () {
        worldTextField.text = LoadLevelScript.topBarLevelName;
        scoreTextField.text = addToStartOfString(ScoreKeeper.score.ToString(), 6);
        coinsCollectedTextField.text = "x" + addToStartOfString(ScoreKeeper.coins.ToString(), 2);
        timeLeftTextField.text = addToStartOfString(ScoreKeeper.timeLeft.ToString(), 3);
	}

    private string addToStartOfString(string s, int digitCount) {
        return s.PadLeft(digitCount, '0');
    }
}
