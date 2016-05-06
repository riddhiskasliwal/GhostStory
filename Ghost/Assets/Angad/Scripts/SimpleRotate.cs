using UnityEngine;
using System.Collections;

public class SimpleRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	//Rotates the pipe pieces in non essential pipes

	void OnMouseDown() {
		if (rotate.block == 1) {
			float p = transform.eulerAngles.z;
			transform.Rotate (0, 0, 90);
		}
		//print (a);
	}
}
