using UnityEngine;
using System.Collections;
public class EnemyMovement : MonoBehaviour
{
	public Transform farEnd;
	private Vector3 frometh;
	private Vector3 untoeth;
	private Animator anim;
	private float secondsForOneLength = 6f;
	private int direction = 1;
	private GUISkin gui;
	public float min = -25f, max=5f;
	public static string headertext = "Score:  Health: ";
	private float x, y, z;
	void Start()
	{
		frometh = transform.position;
		untoeth = farEnd.position;
		x = transform.localScale.x;
		y = transform.localScale.y;
		z = transform.localScale.z;
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update()
	{
		anim.SetInteger ("direction", direction);
		transform.position = Vector3.Lerp(frometh, untoeth,
			Mathf.SmoothStep(0f,1f,
				Mathf.PingPong(Time.time/secondsForOneLength, 1f)
			) );
		if (transform.position.x >= max) {
			transform.localScale = new Vector3(-1*x, y, z);
		}
		if (transform.position.x <= min) {
			transform.localScale = new Vector3(x, y, z);
		}
	}
	void OnTriggerEnter2D(Collider2D obj ){
		string name = obj.gameObject.name;
		if (name == "Player") {
			print ("colliding with the rat");
		}
	}
	void OnGUI(){
		GUI.Box (new Rect (0, 0, 800, 45), headertext);
	}
}