using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class hallway : MonoBehaviour {

	public static bool stairs_entry = false;
	public static bool bathroom_entry = false;
	public static bool shop_entry = false;
	public static bool shop_entrance = false;
	public static bool back_hall = false;
	public static bool symbol_entry = false;
	public static bool hall2_entry= false;
	public static bool fountain_entry= false;
	private string temp;


	// Use this for initialization
	void Start () {
		if (UpperBar.levelComplete == 0) {
			UpperBar.next (0);
		} else if (UpperBar.levelComplete == 2) {
			UpperBar.text = "Task: Find the broken ghost seal! Maybe check upstairs";
		}  else if (UpperBar.levelComplete == 3) {
			UpperBar.text = "Task: Find the broken ghost seal! Maybe check upstairs";
		} else if (UpperBar.levelComplete == 4) {
			UpperBar.text = "Task: Go to the roof and check where the CYM Ghost went";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (UpperBar.levelComplete > 0) {
			Destroy (GameObject.FindGameObjectWithTag ("Audio"));
		}
	
	}


	void OnTriggerEnter2D (Collider2D obj) {
		if (obj.gameObject.name == "Player") {
			if(gameObject.name == "StairEntry") {
				stairs_entry = true;
			}
			if(gameObject.name == "BathroomEntry"){
				if (UpperBar.levelComplete == 0) {
					if (temp != "Press Enter to interact with doors and exits" )
						temp = UpperBar.text;
					UpperBar.text = "Press Enter to interact with doors and exits";
					StartCoroutine ("tempMessage");
				}
				bathroom_entry = true;
			}
			if(gameObject.name == "ShopEntry"){
				shop_entry = true;
			}
			if(gameObject.name == "Shop_Entrance"){
				shop_entrance = true;
			}
			if (gameObject.name == "ToHall") {
				back_hall = true;
			}
			if (gameObject.name == "SymbolEntry") {
				symbol_entry = true;
			}
			if (gameObject.name == "ExitFountain") {
				fountain_entry = true;
			}
			if (gameObject.name == "Hall2Entry") {
				UpperBar.score += 20;
				hall2_entry = true;
			}


		} 
	}
	void OnTriggerExit2D (Collider2D obj) {
		if (obj.gameObject.name == "Player") {
			if(gameObject.name == "StairEntry"){
				stairs_entry = false;
			}
			if(gameObject.name == "BathroomEntry"){
				bathroom_entry = false;
			}
			if(gameObject.name == "ShopEntry"){
				shop_entry = false;
			}
			if (gameObject.name == "ToHall") {
				back_hall = false;
			}
			if (gameObject.name == "SymbolEntry") {
				symbol_entry = false;
			}
			if (gameObject.name == "Hall2Entry") {
				hall2_entry = false;
			}
			if(gameObject.name == "Shop_Entrance"){
				shop_entrance = false;
			}
		} 
	}

	IEnumerator tempMessage(){
		yield return new WaitForSeconds (3);
		UpperBar.text = temp;
	}
}
