using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Text worldTextField;
    public Text scoreTextField;
    public Text coinsCollectedTextField;
	
	// Update is called once per frame
	void Update () {
        worldTextField.text = LoadLevelScript.topBarLevelName;
        scoreTextField.text = addToStartOfString(ScoreKeeper.score.ToString(), 6);
        coinsCollectedTextField.text = "x" + addToStartOfString(ScoreKeeper.coins.ToString(), 2);
	}

    private string addToStartOfString(string s, int digitCount) {
        return s.PadLeft(digitCount, '0');
    }
}
