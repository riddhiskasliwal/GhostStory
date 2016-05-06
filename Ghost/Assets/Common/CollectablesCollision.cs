using UnityEngine;
using System.Collections;

public class CollectablesCollision : MonoBehaviour {

	// Use this for initialization
	public static bool bomb_picked;
	public static bool potion_picked=false;
	public static bool can_shoot = false;
	public static bool can_hit = false;
	public GameObject bullet;
	public AudioClip collectedCoinSound; 


	void Start () {
		bomb_picked = false;
	}

	// Update is called once per frame
	void Update () {
		
	}
	//Handles collecting objects in Park n Shop
	void OnTriggerEnter2D(Collider2D obj ){
		string other = obj.gameObject.name;
		string collectable = gameObject.name;
		string collectableTag = gameObject.tag;
		if (other == "Player") {
			if (collectable == "Bomb") {
				UpperBar.text = "You can use this bomb only once. Use it by pressing 'b'";
				bomb_picked = true;
				Destroy (gameObject, 0.3f);
			}
			if (collectable == "Potion") {
				UpperBar.levelComplete++;
				UpperBar.text = "You have found the necklace! Now fix the broken seal!";
				potion_picked = true;
			}
			if (collectable == "Shooter") {
				UpperBar.text = "You got an unlimited supply of bullets. Use them to get back to the hallway.";
				can_shoot = true;
			}
			if (collectable == "g-wall") {
				can_hit = true;
			}
			//or if collectable == (anthing that boosts score)
			if (collectableTag == "coin") {
				UpperBar.score ++;
				AudioSource.PlayClipAtPoint(collectedCoinSound, transform.position);
			}

			if (collectable != "g-wall") {
				UpperBar.score ++;
				AudioSource.PlayClipAtPoint(collectedCoinSound, transform.position);
				Destroy (gameObject, 0.3f);
			}
		}
	}
	void OnTriggerExit2D(Collider2D obj){
		string name = obj.gameObject.name;
		if (name == "Player" && gameObject.name == "g-wall") {
			can_hit = false;
		}
	}
}
