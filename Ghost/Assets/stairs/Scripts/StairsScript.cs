using UnityEngine;
using System.Collections;


public class StairsScript : MonoBehaviour {

	public AudioClip thunder;
	public int thunderWait = 5;
	bool keepPlaying = true;

	void Start() {
		StartCoroutine(SoundThunder());
	}

	void Update() {}

	IEnumerator SoundThunder() {
		while (keepPlaying) {
			GetComponent<AudioSource>().PlayOneShot(thunder);
			yield return new WaitForSeconds(thunderWait);
		}
	}

}