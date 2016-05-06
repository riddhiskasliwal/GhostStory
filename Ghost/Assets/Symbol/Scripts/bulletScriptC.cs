using UnityEngine;
using System.Collections;

public class bulletScriptC : MonoBehaviour {

	public int speed = 6;

	void  Start (){
		Rigidbody2D bullet = GetComponent<Rigidbody2D>();
		bullet.velocity = new Vector2(0, speed); 
	}

	void  OnBecameInvisible (){
		Destroy(gameObject); 
	}
}
