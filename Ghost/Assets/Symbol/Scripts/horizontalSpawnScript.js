#pragma strict
// Variable to store the enemy prefab
public var ghost: GameObject;
public var ghostBeam : GameObject;
//public var symbolPiece : GameObject;
// Variable to know how fast we should create new enemies
public var spawnTimeGhostAndBeam : float = 1;
//public var spawnTimeSymbolPiece : float = 5;

function Start() {
	// Call the 'addEnemy' function every 'spawnTime' seconds
	InvokeRepeating("addGhostAndBeam", 0, spawnTimeGhostAndBeam);
	//InvokeRepeating("addSymbolPiece", spawnTimeSymbolPiece, spawnTimeSymbolPiece);
}

// New function to spawn an enemy
function addGhostAndBeam() {
	// Variables to store the X position of the spawn object
	var y1 = transform.position.y - GetComponent.<Renderer>().bounds.size.y/2; 
	var y2 = transform.position.y; //+ GetComponent.<Renderer>().bounds.size.y/2;
	var spawnPointY = Random.Range(y1, y2);

	// Randomly pick a point within the spawn object
	var spawnPointGhost = new Vector2(transform.position.x + 0.1, spawnPointY);
	var spawnPointGhostBeam = new Vector2(transform.position.x - 10, spawnPointY);

	// Create an enemy at the 'spawnPoint' position
	Instantiate(ghost, spawnPointGhost, Quaternion.identity);
//	pause();
	Instantiate(ghostBeam, spawnPointGhostBeam, Quaternion.identity);
}

function pause(){
	yield WaitForSeconds(3);
}

//function addSymbolPiece() {
//	// Variables to store the X position of the spawn object
//	var x1 = transform.position.x - GetComponent.<Renderer>().bounds.size.x/2; 
//	var x2 = transform.position.x + GetComponent.<Renderer>().bounds.size.x/2;
//
//	// Randomly pick a point within the spawn object
//	var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);
//
//	// Create an enemy at the 'spawnPoint' position
//	Instantiate(symbolPiece, spawnPoint, Quaternion.identity);
//}