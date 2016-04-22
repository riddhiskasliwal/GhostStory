using UnityEngine;
using System.Collections;


public class Player_Movements : MonoBehaviour {

	public float speed = 10f;
	private Rigidbody2D player;
	private Animator anim;
	private float x, y, pos_y;
	private bool isGrounded;
	public float jumpForce = 500f;
	public GameObject bomb;
	private int bomb_throw;
	public GameObject bullet;
	public static int players_dir = 1;
	// Use this for initialization
	void Start () {
		player = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		x = player.transform.localScale.x;
		y = player.transform.localScale.y;
		pos_y = player.transform.position.y;
		isGrounded = true;
		bomb_throw = 0;
		CollectablesCollision.bomb_picked = false;
	}
	void Update () {
		anim.SetFloat ("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
		anim.SetBool ("Grounded", isGrounded);
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			players_dir = -1;
			transform.localScale = new Vector3(-1*x, y, 1);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			players_dir = 1;
			transform.localScale = new Vector3(x, y, 1);
		}
		if (Mathf.Abs(player.transform.position.y-pos_y) <= 0.1f) {
			isGrounded = true;
		}
	}
	void FixedUpdate(){
		float translation = Input.GetAxis("Horizontal") * speed;
		translation *= Time.deltaTime;
		transform.Translate (translation, 0, 0);
		if (Input.GetKeyDown ("space") && isGrounded) {
			isGrounded = false;
			player.AddForce (Vector3.up * jumpForce);
			StartCoroutine ("grounded");
		} 
		if (Input.GetKeyDown ("b")) {
			if (bomb_throw == 0 && CollectablesCollision.bomb_picked) {
				bomb_throw += 1;
				Instantiate (bomb, transform.position, Quaternion.identity);
			} 
			if (CollectablesCollision.can_shoot){
				Instantiate (bullet, transform.position, Quaternion.identity);
			}
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			print ("you hit enter");
			if (hallway.stairs_entry) {
				System.Threading.Thread.Sleep (2000);
				Application.LoadLevel ("stairs");
				hallway.stairs_entry = false;
			}
			if (hallway.bathroom_entry) {
				System.Threading.Thread.Sleep (2000);
				Application.LoadLevel ("Bathroom");
				hallway.bathroom_entry = false;
			}
			if (hallway.shop_entry) {
				System.Threading.Thread.Sleep (2000);
				Application.LoadLevel ("Level2");
				hallway.shop_entry = false;
			}
			if (hallway.back_hall) {
				System.Threading.Thread.Sleep (2000);
				Application.LoadLevel ("hallway");
				hallway.back_hall = false;
			}
			if (hallway.symbol_entry) {
				System.Threading.Thread.Sleep (2000);
				Application.LoadLevel ("symbol");
				hallway.symbol_entry = false;
			}
			print ("hi");
			if (hallway.hall2_entry) {
				print ("heree");
				System.Threading.Thread.Sleep (2000);
				Application.LoadLevel ("hallway_2");
				hallway.hall2_entry = false;
			}
		}
	}
	IEnumerator grounded(){
		yield return new WaitForSeconds (3/2);
		isGrounded = true;
	}
	// Update is called once per frame
	/*void Update () {
		anim.SetFloat ("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
		anim.SetBool ("Grounded", isGrounded);
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3(-1*x, y, 1);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3(x, y, 1);
		}
		if (Mathf.Abs(player.transform.position.y-pos_y) <= 0.2f) {
			isGrounded = true;
		}
	}
	void FixedUpdate(){
		float translation = Input.GetAxis("Horizontal") * speed;
		translation *= Time.deltaTime;
		transform.Translate (translation, 0, 0);
		if (Input.GetKeyDown ("space") && isGrounded) {
			isGrounded = false;
			transform.Translate (Vector3.up * 100 * 0.018f);
			StartCoroutine ("Fall");
		}
	}
	IEnumerator Fall(){
		yield return new WaitForSeconds (3/2);
		transform.Translate (Vector3.up * -100 * 0.018f);
		isGrounded = true;
	}*/
}
