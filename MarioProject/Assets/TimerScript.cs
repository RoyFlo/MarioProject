using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

    public string nextSceneLoad;

	// Use this for initialization
	IEnumerator Start () {
        yield return StartCoroutine("LoadWorld");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LoadWorld() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextSceneLoad);
    }
}
