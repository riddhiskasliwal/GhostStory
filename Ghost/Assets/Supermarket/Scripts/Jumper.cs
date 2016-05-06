using UnityEngine;
using System.Collections;

public class Jumper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D obj){
		string name = obj.gameObject.name;
		if (name == "Player") {
			obj.transform.Translate (Vector3.up * 25);
			StartCoroutine ("Fall");
		}
	}
	IEnumerator Fall(){
		yield return new WaitForSeconds (3 / 2);
	}
}
