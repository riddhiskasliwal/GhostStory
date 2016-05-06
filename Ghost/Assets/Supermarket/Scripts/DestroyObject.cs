using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine ("destroy");
	}
	IEnumerator destroy(){
		yield return new WaitForSeconds (3/2);
		Destroy (gameObject);
	}
}
