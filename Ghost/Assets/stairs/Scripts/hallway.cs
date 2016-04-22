using UnityEngine;
using System.Collections;

public class hallway : MonoBehaviour {

	public static bool stairs_entry = false;
	public static bool bathroom_entry = false;
	public static bool shop_entry = false;
	public static bool back_hall = false;
	public static bool symbol_entry = false;
	public static bool hall2_entry= false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D (Collider2D obj) {
		if (obj.gameObject.name == "Player") {
			if(gameObject.name == "StairEntry"){
				stairs_entry = true;
			}
			if(gameObject.name == "BathroomEntry"){
				bathroom_entry = true;
			}
			if(gameObject.name == "ShopEntry"){
				shop_entry = true;
			}
			if (gameObject.name == "ToHall") {
				back_hall = true;
			}
			if (gameObject.name == "SymbolEntry") {
				symbol_entry = true;
			}
			if (gameObject.name == "Hall2Entry") {
				print ("exiting");
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
		} 
	}
}
