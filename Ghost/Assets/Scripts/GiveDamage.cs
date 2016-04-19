using UnityEngine;
using System.Collections;

public class GiveDamage : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D rb;
	private GameObject player;
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (gameObject.name == "Weapon(Clone)") {
			rb = GetComponent<Rigidbody2D> ();
			Vector3 temp = rb.velocity;
			temp = (player.transform.position - transform.position).normalized * 20;
			rb.velocity = temp;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D obj ){
		string name = obj.gameObject.name;
		if (name == "Player") {
			Destroy (gameObject);
		}
	}
	void OnBecameInvisible(){
		if (gameObject.name == "Weapon(Clone)") {
			Destroy (gameObject);
		}
	}
}
