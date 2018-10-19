using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

    public string nextLevelScene;

	// Use this for initialization
	IEnumerator Start () {
        yield return StartCoroutine("LoadWorld");
	}

    IEnumerator LoadWorld() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextLevelScene);
    }
}
