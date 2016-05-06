using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

//This script is responsible for the player movements (left right and jump)
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
	public string notReady = "You're not ready to go here yet.";
	public string beenHere = "You've already been here.";
	public static string temp;
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
			StartCoroutine ("grounded");
			player.AddForce (Vector3.up * jumpForce);
			isGrounded = true;
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
			if (hallway.back_hall) {
				System.Threading.Thread.Sleep (2000);
				SceneManager.LoadScene ("hallway");
				hallway.back_hall = false;
			}
			if (hallway.bathroom_entry) {
				hallway.bathroom_entry = false;
				enter(0, UpperBar.levelComplete, "Janitor");
			}
			if (hallway.shop_entry) {
				hallway.shop_entry = false;
				enter(1, UpperBar.levelComplete, "corridor");
			} if (hallway.shop_entrance) {
				hallway.shop_entrance = false;
				enter(1, UpperBar.levelComplete, "ShopInstr");
			} if (hallway.stairs_entry) {
				hallway.stairs_entry = false;
				if (UpperBar.levelComplete > 2) {
					SceneManager.LoadScene("hallway_2");
				} else {
					enter(2, UpperBar.levelComplete, "StairsInstr");
				}
			}  if (hallway.symbol_entry) {
				hallway.symbol_entry = false;
				enter(3, UpperBar.levelComplete, "SymbolInstr");
			} if (hallway.fountain_entry) {
				hallway.fountain_entry = false;
				enter(4, UpperBar.levelComplete, "OutroSlide1");
			} 
		}
	}
	IEnumerator grounded(){
		yield return new WaitForSeconds (20);
	}

	void enter(int properLevel, int currentLevel, string nextScene) {
		print (properLevel + " " + currentLevel + " " + nextScene);
		if (properLevel == currentLevel) {
			print ("2");
			System.Threading.Thread.Sleep (2000);
			SceneManager.LoadScene (nextScene);
		} else {
			if (UpperBar.text != notReady && UpperBar.text != beenHere) {
				temp = UpperBar.text;
			}
			if (currentLevel < properLevel) {
				UpperBar.text = notReady;

			} else {
				UpperBar.text = beenHere;
			}
			StartCoroutine ("tempMessage");
		}
	}
	IEnumerator tempMessage(){
		yield return new WaitForSeconds (3);
		UpperBar.text = temp;
	}
}
