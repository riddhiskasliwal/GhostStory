using UnityEngine;
using System.Collections;

public class horizontalSpawnScriptC : MonoBehaviour {

	public GameObject ghost;
	public GameObject ghostBeam;
	public float spawnTimeGhostAndBeam = 8f;

	void Start () {
		InvokeRepeating("addGhostAndBeam", 0, spawnTimeGhostAndBeam);
	}

	void addGhostAndBeam (){
		float y1= transform.position.y - GetComponent<Renderer>().bounds.size.y/2; 
		float y2= transform.position.y;
		float spawnPointY= Random.Range(y1, y2);

		Vector2 spawnPointGhost= new Vector2(transform.position.x + 0.1f, spawnPointY);
		Vector2 spawnPointGhostBeam= new Vector2(transform.position.x - 10, spawnPointY);

		Instantiate(ghost, spawnPointGhost, Quaternion.identity);
		Instantiate(ghostBeam, spawnPointGhostBeam, Quaternion.identity);
	}
}
