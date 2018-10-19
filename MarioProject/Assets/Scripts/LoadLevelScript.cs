using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevelScript : MonoBehaviour {

    public static string nextLevelScene = "World1-1";

    public static string levelName = "World 1-1";
    public static string topBarLevelName = "1-1";
    public static string score = "000000";
    public static string livesLeft = "x 03";
    public static string coinsCollected = "x 00";

    public Text levelNameTextField;
    public Text topBarLevelNameTextField;
    public Text scoreTextField;
    public Text livesLeftTextField;
    public Text coinsCollectedTextField;

    IEnumerator Start () {
        levelNameTextField.text = levelName;
        topBarLevelNameTextField.text = topBarLevelName;
        scoreTextField.text = score;
        livesLeftTextField.text = livesLeft;
        coinsCollectedTextField.text = coinsCollected;
        yield return StartCoroutine("LoadNextLevel");
	}

    IEnumerator LoadNextLevel() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(nextLevelScene);
    }
}
