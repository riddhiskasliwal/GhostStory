using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//This script controls the water level in the GhostFlooding mini game
public class water : MonoBehaviour {


	 float height;
	public static int complete=0;

	// Use this for initialization
	void Start () {
		height = -10.09f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(transform.position.y>-0.3) {	
			SceneManager.LoadScene ("GameOver");
			//SceneManager.LoadScene ("Janitor");
		}
		if (rotate.a == 30) {
			
			rotate.block = 0;
			if (transform.position.y > -10) {
				height -= 0.01f;
				transform.position = new Vector3( 0.18f, height, 0.0f );
			}
			if (transform.position.y <= -10) {
				complete = 1;
				UpperBar.levelComplete=1;
				UpperBar.score += 50;
				UpperBar.text = "Task: Find CYM's necklace under the ParknShop";
				SceneManager.LoadScene ("Janitor");
			}
		}
		if (rotate.a != 30) {

			height += 0.0015f;

			transform.position = new Vector3( 0.18f, height, 0.0f );
		}
	}
		
}
