using UnityEngine;
using System.Collections;


public class Player_Movements : MonoBehaviour {

	public float speed = 10f;
	private Rigidbody2D player;
	private Animator anim;
	private float x, y, pos_y;
	private bool isGrounded;
	// Use this for initialization
	void Start () {
		player = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		x = player.transform.localScale.x;
		y = player.transform.localScale.y;
		pos_y = player.transform.position.y;
		isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
		anim.SetBool ("Grounded", isGrounded);
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3(-1*x, y, 1);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3(x, y, 1);
		}
		if (Mathf.Abs(player.transform.position.y-pos_y) <= 0.01f) {
			isGrounded = true;
		}
	}
	void FixedUpdate(){
		float translation = Input.GetAxis("Horizontal") * speed;
		translation *= Time.deltaTime;
		transform.Translate (translation, 0, 0);
		if (Input.GetKeyDown ("space") && isGrounded) {
			isGrounded = false;
			player.AddForce (Vector3.up * 200);
		} 
	}
}
