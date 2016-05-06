using UnityEngine;
using System.Collections;

public class hallway2_symbol : MonoBehaviour {

	// Use this for initialization
	public static Vector3 cracked_symbol_position = new Vector3(21.93f, 0.13f, 0f);
	public static Vector3 new_symbol_position = new Vector3(21.93f, -11.2f, 0f);
	public static Vector3 gate_position = new Vector3(30.46f, -11.25f, 0f);
	public GameObject new_symbol;
	public GameObject old_symbol;
	public GameObject gate;
	void Start () {
		new_symbol.transform.position = new_symbol_position;
		old_symbol.transform.position = cracked_symbol_position;
		gate.transform.position = gate_position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
