using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainScreenGUI : MonoBehaviour {

	// Use this for initialization
	GUIStyle gsTest = new GUIStyle();
	private bool muted = false;
	private bool on_home = true;
	private bool on_intro = false;
	private bool on_outro = false;
	private string button_text = "Turn Music Off";
	void Start () {
		AudioListener.pause = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnLevelWasLoaded( int level )
	{
		if (level != 0) {
			on_home = false;
		} 
		if (level > 0 && level < 8) {
			on_intro = true;
		} else {
			on_intro = false;
		}
		if (level >= 20 && level <= 25) {
			on_outro = true;
		} else {
			on_outro = false;
		}
	}
	void OnGUI(){
		if (on_home) {
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 50), "Start"))
				SceneManager.LoadScene ("IntroductionSlide1");
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 160, 200, 50), button_text)) {
				if (muted) {
					AudioListener.pause = false;
					button_text = "Turn Music Off";
					muted = false;
				} else {
					AudioListener.pause = true;
					button_text = "Turn Music On";
					muted = true;
				}
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 220, 200, 50), "Skip Intro")) {
				SceneManager.LoadScene ("hallway");
			}
			if (GUI.Button (new Rect (Screen.width - 200, 0, 200, 50), "Quit")) {
				Application.Quit ();
			}
		} else if (on_intro) {
			if (GUI.Button (new Rect (Screen.width - 200, 0, 200, 50), "Quit")) {
				Application.Quit ();
			}
			if (GUI.Button (new Rect (Screen.width - 500, 0, 200, 50), "Skip Intro")) {
				SceneManager.LoadScene ("hallway");
			}
		} else if (on_outro) {
			if (GUI.Button (new Rect (Screen.width - 200, 0, 200, 50), "Quit")) {
				Application.Quit ();
			}
			if (GUI.Button (new Rect (Screen.width - 500, 0, 200, 50), "Skip Outro")) {
				SceneManager.LoadScene ("OutroSlide7");
			}
		} else {
			if (GUI.Button (new Rect (Screen.width - 200, 0, 200, 50), "Quit")) {
				Application.Quit ();
			}
		}
		
	}
}
