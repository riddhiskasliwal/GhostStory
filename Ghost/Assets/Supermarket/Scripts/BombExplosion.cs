using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {
	// Use this for initialization
	private Rigidbody2D rb;
	public GameObject explosion_effect;
	public GameObject path;
	private GameObject rat;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Vector3 temp = rb.velocity;
		temp.x = 50;
		rb.velocity = temp;
		rat = GameObject.FindGameObjectWithTag ("Respawn");
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D obj ){
		string name = obj.gameObject.name;
		if (name == "Barrel") {
			Destroy (gameObject);
			Instantiate (explosion_effect, transform.position, Quaternion.identity);
			Destroy (obj.gameObject, 0.1f);
			if (rat.transform.localPosition.x >= 11f) {
				Destroy(rat);
			}
			Instantiate (path, new Vector3(18.12f, -10.3f, 0f), Quaternion.identity);
		}
	}
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
