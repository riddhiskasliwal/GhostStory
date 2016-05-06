using UnityEngine;
using System.Collections;

public class enemyScriptC : MonoBehaviour {

	public GameObject explosionEffect;
	public AudioClip explosionClip;
	public int speed = -5;

	void Start () {
		Rigidbody2D enemy = GetComponent<Rigidbody2D>();
		enemy.velocity = new Vector2 (0, speed);

		Destroy(gameObject, 3);
	}
	
	void OnTriggerEnter2D (Collider2D obj){
		string name= obj.gameObject.name;
		if (name == "bullet(Clone)") {
			Destroy(gameObject);
			Destroy(obj.gameObject); 
			Instantiate(explosionEffect, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(explosionClip, transform.position);
			UpperBar.score += 10;
		}
	}
}
