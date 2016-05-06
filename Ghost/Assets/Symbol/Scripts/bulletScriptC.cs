using UnityEngine;
using System.Collections;

public class bulletScriptC : MonoBehaviour {

	public int speed = 6;
	//Initialising
	void  Start (){
		Rigidbody2D bullet = GetComponent<Rigidbody2D>();
		bullet.velocity = new Vector2(0, speed); 
	}
	//Destro the Game Object
	void  OnBecameInvisible (){
		Destroy(gameObject); 
	}
}
