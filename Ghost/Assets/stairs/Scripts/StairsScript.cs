using UnityEngine;
using System.Collections;


public class StairsScript : MonoBehaviour {

	public AudioClip thunder;
	public float lightningWait = 10f;
	bool keepPlaying = true;

	void Start() {
		StartCoroutine(LightningEffect());
	}

	void Update() {}

	IEnumerator LightningEffect() {
		while (keepPlaying) {
			AudioSource.PlayClipAtPoint(thunder, transform.position);
			 //play thunder sound at random intervals, but at least 5sec apart
			lightningWait = Mathf.Round(Random.value * 15) + 5;
			yield return new WaitForSeconds(lightningWait);
		}
	}

}