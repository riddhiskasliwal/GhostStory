using UnityEngine;
using System.Collections;

public class water : MonoBehaviour {


	 float height;


	// Use this for initialization
	void Start () {
		height = -10.09f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(transform.position.y==0)
		{	print ("Game Over"); 
		}
		if (rotate.a == 29) {
			//print ("won");
			rotate.block = 0;
			if (transform.position.y > -10) {
				height -= 0.005f;
				transform.position = new Vector3( 0.18f, height, 0.0f );
			}
		}
		if (rotate.a != 29) {
			height += 0.001f;

			transform.position = new Vector3( 0.18f, height, 0.0f );
		}
	}
}
