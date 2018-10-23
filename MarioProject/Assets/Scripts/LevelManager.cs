using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public string nextLevel;
    public string nextLevelName;
    public string topBarNextLevelName;
    public string score;
    public string livesLeft;
    public string coinsCollected;

    BGMusicScript bgMusic;

    void Start() {
        bgMusic = FindObjectOfType<BGMusicScript>();

        LoadLevelScript.nextLevelScene = nextLevel;
        LoadLevelScript.levelName = nextLevelName;
        LoadLevelScript.topBarLevelName = topBarNextLevelName;
        LoadLevelScript.score = score;
        LoadLevelScript.livesLeft = livesLeft;
        LoadLevelScript.coinsCollected = coinsCollected;
    }

    IEnumerator OnTriggerEnter2D(Collider2D collider) {
        bgMusic.ExitScene();
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("LevelLoadScene");
    }
}
