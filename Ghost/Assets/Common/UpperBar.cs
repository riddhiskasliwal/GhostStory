using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class UpperBar : MonoBehaviour {

	GUIStyle gsTest = new GUIStyle();
	public static string text;
	public static int score=0;
	public static int health=100;
	public static int levelComplete = 0;

	public static int i = 0;
	public static string[] message = new string[] {"The crying seems to be coming from the girl’s bathroom…","Janitor: What are you doing here? This building has been evacuated!","Janitor: Get out, get out before the ghost comes back!","Janitor: The ghost is on the loose, and it’s angry!","Janitor: Don’t look at me like that!","Janitor: It’s not my fault! I tried! I really tried!","Janitor: But I could not fix the broken ghost seal!","Janitor: The ghost seal on the second floor that traps the ghost!","Janitor: But maybe you can save us - appease the ghost!","Janitor: She loved her precious necklace.", "Janitor: I’ve heard rumors that it might be hidden under the ParknShop.","Janitor: All you have to do is -- " };

	// Use this for initialization
	void Start () {
		gsTest.alignment = TextAnchor.MiddleLeft;
		gsTest.normal.background = MakeTex (800, 1, Color.black);
		gsTest.normal.textColor = Color.white;

		if (Application.loadedLevelName == "Bathroom")
			text = "Task: Connect the pipe ends before you're completely submerged!";
		if (Application.loadedLevelName == "Level2")
			text = "Task: Find CYM's necklace under the ParknShop";
		if (Application.loadedLevelName == "stairs")
			text = "Task: Find the broken ghost seal! Maybe check upstairs";
		if (Application.loadedLevelName == "symbol")
			text = "Task: Collect " + spaceshipScriptC.symbolPiecesGoal + " Symbol Pieces to repair the Ghost Seal!";
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 1) {
			SceneManager.LoadScene ("GameOver");
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

	void OnGUI() {
		GUI.Label( new Rect(200,0,Screen.width-200,35), text, gsTest);
		GUI.Label( new Rect(0,0,100,35), "Score "+score, gsTest);
		GUI.Label( new Rect(100,0,100,35), "Health "+health, gsTest);
		if (Application.loadedLevelName=="Bathroom"||Application.loadedLevelName=="Level2"||Application.loadedLevelName=="stairs"||Application.loadedLevelName=="symbol")
			if(GUI.Button (new Rect (Screen.width-200, 5,50 , 30), "Reset"))
				SceneManager.LoadScene (Application.loadedLevelName);
		if (GUI.Button (new Rect (Screen.width - 100, 5, 50, 30), "Quit"))
			Application.Quit ();
	}

	public static void next(int i){
		text = message [i];
	}

}
