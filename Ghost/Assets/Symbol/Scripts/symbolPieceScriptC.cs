using UnityEngine;
using System.Collections;

public class symbolPieceScriptC : MonoBehaviour {

	public GameObject explosionEffect;
	public AudioClip explosionClip;
	public int speed = -5;

	void Start () {
		Rigidbody2D symbolPiece = GetComponent<Rigidbody2D>();
		symbolPiece.velocity = new Vector2 (0, speed);
		symbolPiece.angularVelocity = Random.Range(-200, 200);

		Destroy(gameObject, 3);
	}

	void OnTriggerEnter2D (Collider2D obj){
		string name= obj.gameObject.name;
		if (name == "bullet(Clone)") {
			Destroy(gameObject);
			Destroy(obj.gameObject); 
			Instantiate(explosionEffect, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(explosionClip, transform.position);
		}
	}
}
