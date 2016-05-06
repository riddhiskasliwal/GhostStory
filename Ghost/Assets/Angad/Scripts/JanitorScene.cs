using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class JanitorScene : MonoBehaviour {

	public static int a=0;
	public int i=0;
	public AudioClip screamClip;
	//Initialises the hallway for the Janitor Scene
	//Handles whether the janiotr is there or not
	void Start () {
		var str = gameObject.transform.name;
		string[]  strArr = str.Split(' ');
		if (strArr [0] == "Platform") {
			a++;
			transform.position = new Vector3 (38f, 0.0f, 0.0f);
		}
		if (water.complete == 0) {
			if (i == 0) {
				UpperBar.next (i);
				i++;
			}
			
		} else {
			transform.Rotate (0, 0, 270);
			transform.position = new Vector3( 100f, -3.5f, 0.0f );
		}
	}
		
	void Update () {
		if (i < UpperBar.message.Length) {
			if (Input.GetKeyDown (KeyCode.I)) {
				UpperBar.next (i);
				i++;
				if (i == UpperBar.message.Length) {
					AudioSource.PlayClipAtPoint(screamClip, transform.position);
					a = 1;
					var str = gameObject.transform.name;
					string[]  strArr = str.Split(' ');
					if (strArr [0] == "Platform") {
						a++;
						transform.position = new Vector3 (-2.3f, 0.0f, 0.0f);
					}
					StartCoroutine (JanitorSpeak ());
				}
			}
		}
	
	}
		 
	private Texture2D MakeTex(int width, int height, Color col)
	{
		Color[] pix = new Color[width*height];

		for(int i = 0; i < pix.Length; i++)
			pix[i] = col;

		Texture2D result = new Texture2D(width, height);
		result.SetPixels(pix);
		result.Apply();

		return result;
	}

	//Controls interaction with the janitor 
	void OnTriggerEnter2D(Collider2D other) {

		if (i == UpperBar.message.Length)
			StartCoroutine (JanitorSpeak ());
		else
			UpperBar.text = "Press the 'i' key to talk to the janitor";
		
	}

	void OnTriggerExit2D(Collider2D other) {
		
	}

	//Function to implement the GUI.Label  

	IEnumerator JanitorSpeak(){

		if (water.complete == 0) {
			if (a == 0) {
				a = 1;
				yield return new WaitForSeconds (3);
				SceneManager.LoadScene ("bathroominstr");

			} else if (a == 1) {
				yield return new WaitForSeconds (3);
				SceneManager.LoadScene ("bathroominstr");
			}
		}
	}



}
