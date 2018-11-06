using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevelScript : MonoBehaviour {

    public Text levelNameTextField;
    public Text topBarLevelNameTextField;
    public Text scoreTextField;
    public Text livesLeftTextField;
    public Text coinsCollectedTextField;

    //These are to set up loading the first level
    public static string nextLevelScene = "World1-1";
    public static string levelName = "World 1-1";
    public static string topBarLevelName = "1-1";
    public static string livesLeft = "x 03";

    IEnumerator Start () {
        levelNameTextField.text = levelName;
        topBarLevelNameTextField.text = topBarLevelName;
        scoreTextField.text = addToStartOfString(ScoreKeeper.score.ToString(), 6);
        livesLeftTextField.text = "x " + addToStartOfString(ScoreKeeper.livesLeft.ToString(), 2);
        coinsCollectedTextField.text = "x" + addToStartOfString(ScoreKeeper.coins.ToString(), 2);
        yield return StartCoroutine("LoadNextLevel");
	}

    IEnumerator LoadNextLevel() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(nextLevelScene);
    }

    private string addToStartOfString(string s, int digitCount) {
        return s.PadLeft(digitCount, '0');
    }
}
