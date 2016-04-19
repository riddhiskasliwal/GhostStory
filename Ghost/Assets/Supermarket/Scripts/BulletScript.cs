using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D rb;
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
	void OnTriggerEnter2D(Collider2D obj ){
		string name = obj.gameObject.name;
		if (name == "Static_Enemy(Clone)" || name == "Ghost" || name == "Weapon(Clone)" || name == "Big_Enemy") {
			Destroy (obj.gameObject);
			Destroy (gameObject);
		}
	}
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
