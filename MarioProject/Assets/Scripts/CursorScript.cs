using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour {

    public GameObject topCursor;
    public GameObject bottomCursor;
    public AudioSource soundSource;
    public string nextSceneLoad;
    public Text finalScore;

    private GameObject activeCursor;

    void Start() {
        activeCursor = topCursor;
        finalScore.text = "Final Score: " + addToString(ScoreKeeper.score.ToString(), 6);
    }

    void Update () {
        if((Input.GetKeyDown("down") || Input.GetKeyDown("s")) && activeCursor == topCursor) {
            soundSource.Play();

            bottomCursor.SetActive(true);
            activeCursor = bottomCursor;

            topCursor.SetActive(false);
        }

        if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && activeCursor == bottomCursor) {
            soundSource.Play();

            topCursor.SetActive(true);
            activeCursor = topCursor;

            bottomCursor.SetActive(false);
        }

        if(Input.GetKeyDown("space")) {
            if (activeCursor == topCursor) {
                ScoreKeeper.resetCoins();
                ScoreKeeper.resetLives();
                ScoreKeeper.resetScore();
                SceneManager.LoadScene(nextSceneLoad);
            }

            if(activeCursor == bottomCursor) {
                Debug.Log("Exiting game...");
                Application.Quit();
            }
        }
	}

    private string addToString(string s, int digits) {
        return s.PadLeft(digits, '0');
    }
}
