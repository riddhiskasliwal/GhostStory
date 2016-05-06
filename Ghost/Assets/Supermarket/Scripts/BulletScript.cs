using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	private static int counterG = 10;
	private static int counterB = 5;
	public AudioClip DamagePlayer; 
	private Rigidbody2D rb;
	//Intialising
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Vector3 temp = rb.velocity;
		if (Player_Movements.players_dir == 1) {
			temp.x = 50;
		} else {
			temp.x = -50;
		}
		rb.velocity = temp;
	}

	// Update is called once per frame
	void Update () {

	}
	//Handle the bullets killing Ghost, Big Enemy, and other small enemies 
	void OnTriggerEnter2D(Collider2D obj ){
		string name = obj.gameObject.name;
		if (name == "Static_Enemy(Clone)" || name == "Weapon(Clone)") {
			UpperBar.score += 10;
			AudioSource.PlayClipAtPoint(DamagePlayer, transform.position);
			Destroy (obj.gameObject);
			Destroy (gameObject);
		}
		if (name == "Ghost") {
			AudioSource.PlayClipAtPoint(DamagePlayer, transform.position);
			Destroy (gameObject);
			counterG--;
		}
		if (name == "Big_Enemy") {
			AudioSource.PlayClipAtPoint(DamagePlayer, transform.position);
			Destroy (gameObject);
			counterB--;
		}
		if (name == "Ghost" && counterG == 0) {
			UpperBar.score += 50;
			UpperBar.health += 10;
			Destroy (obj.gameObject);
			Destroy (gameObject);
		}
		if (name == "Big_Enemy" && counterB == 0) {
			UpperBar.score += 50;
			UpperBar.health += 10;
			Destroy (obj.gameObject);
			Destroy (gameObject);
		}
	}
	//Destroy the corresponding Game Object
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
