using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public string nextLevel;
    public string nextLevelName;
    public string topBarNextLevelName;
    public string livesLeft;

    BGMusicScript bgMusic;

    void Start() {
        bgMusic = FindObjectOfType<BGMusicScript>();
    }

    IEnumerator OnTriggerEnter2D(Collider2D collider) {
        bgMusic.ExitScene();
        yield return new WaitForSeconds(6);

        LoadLevelScript.nextLevelScene = nextLevel;
        LoadLevelScript.levelName = nextLevelName;
        LoadLevelScript.topBarLevelName = topBarNextLevelName;
        LoadLevelScript.livesLeft = livesLeft;

        SceneManager.LoadScene("LevelLoadScene");
    }
}
