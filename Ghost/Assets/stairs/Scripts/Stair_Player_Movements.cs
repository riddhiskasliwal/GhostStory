using UnityEngine;
using System.Collections;


public class Stair_Player_Movements : MonoBehaviour {

	
	public float Speed = 5;
	private float movex = 0f;
	private float movey = 0f;

	//speed
	// public float speed = 5;
	// how often to randomize whether to reverse the direction
	public float jumbleTime = 5;
	// variables to store whether the horizontal or vertical movement is reverse to the input
	public float reverseX = 1;
	public float reverseY = 1;

	private Rigidbody2D player;
	private Animator anim;
	private float x, y;
	// private bool isGrounded;
	// public float jumpForce = 500f;
	// public GameObject bomb;
	// private int bomb_throw;
	// public GameObject bullet;

	// Use this for initialization
	void Start () {
		// every jumbleTime seconds, determine whether or not to reverse X or Y input
		InvokeRepeating("whetherReverse", jumbleTime, jumbleTime);
		player = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		x = player.transform.localScale.x;
		y = player.transform.localScale.y;
		// pos_y = player.transform.position.y;
		// isGrounded = true;
		// bomb_throw = 0;
		// CollectablesCollision.bomb_picked = false;
	}
	void Update () {
		movex = Input.GetAxis ("Horizontal");
		movey = Input.GetAxis ("Vertical");
		anim.SetFloat ("Speed", Mathf.Abs(Mathf.Max(movex, movey) * reverseX));

		
		// if (Input.GetAxis ("Horizontal") < -0.1f) {
		// 	transform.localScale = new Vector3(-1*x, y, 1);
		// }
		// if (Input.GetAxis ("Horizontal") > 0.1f) {
		// 	transform.localScale = new Vector3(x, y, 1);
		// }
		// if (Mathf.Abs(player.transform.position.y-pos_y) <= 0.1f) {
		// 	isGrounded = true;
		// }
	}
	void FixedUpdate(){
		
		
		// move component, reversing direction of x and y if necessary
		GetComponent<Rigidbody2D>().velocity = new Vector2 (movex * reverseX * Speed, movey * reverseY * Speed);

		// float translation = Input.GetAxis("Horizontal") * speed * reverseX;
		// translation *= Time.deltaTime;
		// transform.Translate (translation, 0, 0);
		if (Input.GetKeyDown (KeyCode.Return)) {
			print("hit return");
			if (hallway.hall2_entry) {
				print ("heree");
				System.Threading.Thread.Sleep (2000);
				Application.LoadLevel ("hallway_2");
				hallway.hall2_entry = false;
			}
		}
	}
	// IEnumerator grounded(){
	// 	yield return new WaitForSeconds (3/2);
	// 	isGrounded = true;
	// }

	void whetherReverse () {
		// randomly reverse X or Y movement (reverseX or reverseY will be -1 or 1)
		reverseX = Mathf.Pow(-1, Mathf.Round(Random.value));
		reverseY = Mathf.Pow(-1, Mathf.Round(Random.value));
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
