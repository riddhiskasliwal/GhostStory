using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class spaceshipScriptC : MonoBehaviour {

	public GameObject bullet;
	public GameObject explosionEffect;
	public AudioClip yellingClip;
	public AudioClip symbolCollectClip;
	public static int symbolPiecesCurrent = 0;
	public static int symbolPiecesGoal = 10;

	void Update () {
		Rigidbody2D spaceship = GetComponent<Rigidbody2D> ();
		spaceship.velocity = new Vector2 (Input.GetAxis ("Horizontal") * 10, Input.GetAxis ("Vertical") * 10);

		if (Input.GetKeyDown("space")) {
			Instantiate(bullet, transform.position + new Vector3(0,0.75f,0), Quaternion.identity); 
		}
	}

	void OnTriggerEnter2D (Collider2D obj){
		string name= obj.gameObject.name;

		if (name == "enemy(Clone)") {
			Destroy(obj.gameObject); 
			Instantiate(explosionEffect, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(yellingClip, transform.position);
			if (UpperBar.health > 0) {
				UpperBar.health -= 2;
			}
		}

		if (name == "ghostBeam(Clone)") {
			
			Destroy(obj.gameObject); 
			Instantiate(explosionEffect, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(yellingClip, transform.position);
			if (UpperBar.health > 0) {
				UpperBar.health -= 5;
			}
		}

		if (name == "symbolPiece(Clone)") {
			AudioSource.PlayClipAtPoint(symbolCollectClip, transform.position);
			Destroy(obj.gameObject); 
			symbolPiecesCurrent += 1;
			if (symbolPiecesCurrent % 2 == 0) {
				UpperBar.text = "Awesome! You have collected " + symbolPiecesCurrent + " out of 10 pieces! Keep Going";
			} else {
				UpperBar.text = "Nice! You have collected " + symbolPiecesCurrent + " out of 10 pieces!";
			}
			if (symbolPiecesCurrent == symbolPiecesGoal) {
				System.Threading.Thread.Sleep (500);
				hallway2_symbol.gate_position = new Vector3 (30.46f, 0.23f, 0f);
				SceneManager.LoadScene ("hallway_2");
				UpperBar.levelComplete += 1;
				Vector3 temp = hallway2_symbol.cracked_symbol_position;
				hallway2_symbol.cracked_symbol_position = hallway2_symbol.new_symbol_position;
				hallway2_symbol.new_symbol_position = temp;
				UpperBar.text = "Task: Go to the roof and check where the CYM Ghost went";
			}
		}
	}
}
