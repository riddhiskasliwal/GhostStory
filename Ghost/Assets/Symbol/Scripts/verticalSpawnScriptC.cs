using UnityEngine;
using System.Collections;

public class verticalSpawnScriptC : MonoBehaviour {

	public GameObject enemy;
	public GameObject symbolPiece;
	public float spawnTimeEnemy = 0.25f;
	public float spawnTimeSymbolPiece = 5f;

	void Start () {
		InvokeRepeating("addEnemy", spawnTimeEnemy, spawnTimeEnemy);
		InvokeRepeating("addSymbolPiece", spawnTimeSymbolPiece, spawnTimeSymbolPiece);
	}
	
	void addEnemy (){
		float x1= transform.position.x - GetComponent<Renderer>().bounds.size.x/2; 
		float x2= transform.position.x + GetComponent<Renderer>().bounds.size.x/2;
		Instantiate(enemy, new Vector2(Random.Range(x1, x2), transform.position.y), Quaternion.identity);
	}

	void addSymbolPiece (){
		float x1= transform.position.x - GetComponent<Renderer>().bounds.size.x/2; 
		float x2= transform.position.x + GetComponent<Renderer>().bounds.size.x/2;
		Instantiate(symbolPiece, new Vector2(Random.Range(x1, x2), transform.position.y), Quaternion.identity);
	}
}
