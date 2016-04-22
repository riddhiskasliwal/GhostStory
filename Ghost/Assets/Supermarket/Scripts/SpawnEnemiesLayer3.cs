using UnityEngine;
using System.Collections;

public class SpawnEnemiesLayer3 : MonoBehaviour {

	// Use this for initialization
	public GameObject enemy;
	private float x1 = -39f;
	private float x2 = 24f;
	private float y1 = -37f;
	private float y2 = -26f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D obj ){
		string name = obj.gameObject.name;
		if (name == "Player" && CollectablesCollision.potion_picked){
			CollectablesCollision.potion_picked = false;
			float r = Random.Range (5, 7);
			float x, y;
			for (int i = 0; i < r; i++) {
				x = Random.Range (x1, x2);
				y = Random.Range (y1, y2);
				Instantiate (enemy, new Vector3 (x, y, 0), Quaternion.identity);
			}
		}
	}
}
