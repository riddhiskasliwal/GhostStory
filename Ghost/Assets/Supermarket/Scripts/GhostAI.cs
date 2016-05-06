using UnityEngine;
using System.Collections;

public class GhostAI : MonoBehaviour {

	// Use this for initialization
	public float delay=5f;
	public float speed=5f;
	public GameObject ghost_weapon;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D obj){
		if (CollectablesCollision.can_hit) {
			InvokeRepeating ("Shoot", delay, speed);
		} else if(!CollectablesCollision.can_hit) {
			CancelInvoke ("Shoot");
		}
	}
	void Shoot(){
		Instantiate (ghost_weapon, new Vector3(-6.036f, -38.62f, 0f), Quaternion.identity);
	}
}
