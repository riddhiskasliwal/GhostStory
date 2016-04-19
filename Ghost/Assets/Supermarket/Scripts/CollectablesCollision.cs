using UnityEngine;
using System.Collections;

public class CollectablesCollision : MonoBehaviour {

	// Use this for initialization
	public static bool bomb_picked;
	public static bool potion_picked=false;
	public static bool can_shoot = false;
	public static bool can_hit = false;
	public GameObject bullet;
	void Start () {
		bomb_picked = false;
	}

	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D obj ){
		string name = obj.gameObject.name;
		if (name == "Player" && gameObject.name == "Bomb") {
			bomb_picked = true;
			Destroy (gameObject, 0.3f);
		}
		if (name == "Player" && gameObject.name == "Potion") {
			potion_picked = true;
		}
		if (name == "Player" && gameObject.name == "Shooter") {
			can_shoot = true;
		}
		if (name == "Player" && gameObject.name == "g-wall") {
			can_hit = true;
		}
		if (name == "Player" && gameObject.name != "g-wall") {
			Destroy (gameObject, 0.3f);
		}
	}
	void OnTriggerExit2D(Collider2D obj){
		string name = obj.gameObject.name;
		if (name == "Player" && gameObject.name == "g-wall") {
			can_hit = false;
		}
	}
}
