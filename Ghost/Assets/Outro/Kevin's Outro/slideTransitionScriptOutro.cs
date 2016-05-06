using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class slideTransitionScriptOutro : MonoBehaviour {

	public int slideLengthInSeconds;
	private string nextScene;
	private int nextSceneNum;
	void Start () {
		nextSceneNum = Int32.Parse ("" + Application.loadedLevelName[Application.loadedLevelName.Length - 1]);
		nextSceneNum++;
		nextScene = "OutroSlide" + nextSceneNum;
		StartCoroutine(Coroutine());
	}

	IEnumerator Coroutine(){
		yield return new WaitForSeconds(slideLengthInSeconds);
		if (nextSceneNum != 8) {
			SceneManager.LoadScene (nextScene);
		}
	}
}
