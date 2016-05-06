using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {
	// Use this for initialization
	private Rigidbody2D rb;
	public GameObject explosion_effect;
	public GameObject path;
	private GameObject rat;
	public AudioClip explosion; 
	private bool rat_exists = true;
	
	//Initialise the scene
	void Start () {
		UpperBar.text = "Task: Find the CYM ghost's jewellery";
		rb = GetComponent<Rigidbody2D> ();
		Vector3 temp = rb.velocity;
		if (Player_Movements.players_dir == 1) {
			temp.x = 50;
		} else {
			temp.x = -50;
		}
		rb.velocity = temp;
		rat = GameObject.FindGameObjectWithTag ("Respawn");
	}
	
	// Update is called once per frame
	void Update () {

	}
	//Control the Explosion of the barrel and the rat 
	void OnTriggerEnter2D(Collider2D obj ){
		string name = obj.gameObject.name;
		if (name == "Barrel") {
			AudioSource.PlayClipAtPoint(explosion, transform.position);
			Destroy (gameObject);
			Instantiate (explosion_effect, transform.position, Quaternion.identity);
			Destroy (obj.gameObject, 0.1f);
			if (rat_exists && rat.transform.localPosition.x >= 11f) {
				UpperBar.score += 50;
				UpperBar.health += 10;
				Destroy(rat);
			}
			Instantiate (path, new Vector3(18.12f, -10.3f, 0f), Quaternion.identity);
		} 
		if (obj.gameObject.name == "Enemy_rats") {
			UpperBar.score += 50;
			UpperBar.health += 10;
			rat_exists = false;
			Instantiate (explosion_effect, transform.position, Quaternion.identity);
			Destroy (obj.gameObject);
		}
	}
	//Destroy the game object
	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
