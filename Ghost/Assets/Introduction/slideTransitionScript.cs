using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class slideTransitionScript : MonoBehaviour {

	public int slideLengthInSeconds;
	private string nextScene;
	private int nextSceneNum;
	void Start () {
		nextSceneNum = Int32.Parse ("" + Application.loadedLevelName[Application.loadedLevelName.Length - 1]);
		nextSceneNum++;
		if (nextSceneNum == 8) {
			nextScene = "hallway";
		} else {
			nextScene = "IntroductionSlide" + nextSceneNum;
		}
		StartCoroutine(Coroutine());
	}
	
	IEnumerator Coroutine(){
		yield return new WaitForSeconds(slideLengthInSeconds);
		SceneManager.LoadScene(nextScene);
	}
}
