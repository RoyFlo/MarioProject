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
    public GameObject player;

    private BoxCollider2D exitCollider;

    BGMusicScript bgMusic;

    void Start() {
        bgMusic = FindObjectOfType<BGMusicScript>();
        exitCollider = GameObject.Find("Exit").GetComponent<BoxCollider2D>();
        previousLevel = 0;
    }

    void OnEnable() {
        switch (previousLevel) {
            case 2:
                player.transform.position = new Vector3(24.76f, -0.45f, 0.0f);
                break;
            case 4:
                player.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case 7:
                player.transform.position = new Vector3(20.07f, 7.31f, 0.0f);
                break;
            default:
                break;
        }
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

    void OnTriggerStay2D(Collider2D trig) {
        if (trig.gameObject.tag == "Player" && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))) {
            previousLevel = SceneManager.GetActiveScene().buildIndex;
        }
    }
}
