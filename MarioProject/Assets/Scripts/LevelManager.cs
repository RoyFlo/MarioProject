using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static int previousLevel;

    public string nextLevel;
    public string nextLevelName;
    public string topBarNextLevelName;
    public string livesLeft;

    private static int currentLevel;
    private BoxCollider2D exitCollider;

    BGMusicScript bgMusic;

    void Start() {
        bgMusic = FindObjectOfType<BGMusicScript>();
        exitCollider = GameObject.Find("Exit").GetComponent<BoxCollider2D>();
        previousLevel = 0;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    IEnumerator OnTriggerEnter2D(Collider2D collider) {
        Debug.Log(exitCollider.tag);
        bgMusic.ExitScene();
        yield return new WaitForSeconds(6);

        if (exitCollider.tag == "FinalLevel") {
            SceneManager.LoadScene("GameWon");
            yield break;
        }

        LoadLevelScript.nextLevelScene = nextLevel;
        LoadLevelScript.levelName = nextLevelName;
        LoadLevelScript.topBarLevelName = topBarNextLevelName;
        LoadLevelScript.livesLeft = livesLeft;

        SceneManager.LoadScene("LoadLevelScene");
    }

    public static void ReloadScene() {
        SceneManager.LoadScene("LoadLevelScene");
    }
}
