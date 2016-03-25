using UnityEngine;
using System.Collections;


public class Player_Movements : MonoBehaviour {

	public float speed = 10f;
	private Rigidbody2D player;
	private Animator anim;
	private float x, y;
	// Use this for initialization
	void Start () {
		player = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		x = player.transform.localScale.x;
		y = player.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3(-1*x, y, 1);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3(x, y, 1);
		}
	}
	void FixedUpdate(){
		float translation = Input.GetAxis("Horizontal") * speed;
		translation *= Time.deltaTime;
		transform.Translate (translation, 0, 0);
	}
}
