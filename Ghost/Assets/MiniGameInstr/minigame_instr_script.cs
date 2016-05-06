using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class minigame_instr_script : MonoBehaviour {

	private string scene_name;

	// Use this for initialization
	void Start () {
		scene_name = this.name;
		print(scene_name);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			if (scene_name == "bathroominstr") {
				SceneManager.LoadScene ("Bathroom");
			}
			if (scene_name == "shopinstr") {
				SceneManager.LoadScene ("Level2");
			}
			if (scene_name == "stairinstr") {
				SceneManager.LoadScene ("stairs");
			}
			if (scene_name == "symbolinstr") {
				SceneManager.LoadScene ("symbol");
			}
		}
	}
}
