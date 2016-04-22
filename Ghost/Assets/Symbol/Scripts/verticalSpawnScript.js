#pragma strict
// Variable to store the enemy prefab
public var enemy : GameObject;
public var symbolPiece : GameObject;
// Variable to know how fast we should create new enemies
public var spawnTimeEnemy : float = 0.25;
public var spawnTimeSymbolPiece : float = 5;

function Start() {
	// Call the 'addEnemy' function every 'spawnTime' seconds
	InvokeRepeating("addEnemy", spawnTimeEnemy, spawnTimeEnemy);
	InvokeRepeating("addSymbolPiece", spawnTimeSymbolPiece, spawnTimeSymbolPiece);
}

// New function to spawn an enemy
function addEnemy() {
	// Variables to store the X position of the spawn object
	var x1 = transform.position.x - GetComponent.<Renderer>().bounds.size.x/2; 
	var x2 = transform.position.x + GetComponent.<Renderer>().bounds.size.x/2;

	// Randomly pick a point within the spawn object
	var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

	// Create an enemy at the 'spawnPoint' position
	Instantiate(enemy, spawnPoint, Quaternion.identity);
}

function addSymbolPiece() {
	// Variables to store the X position of the spawn object
	var x1 = transform.position.x - GetComponent.<Renderer>().bounds.size.x/2; 
	var x2 = transform.position.x + GetComponent.<Renderer>().bounds.size.x/2;

	// Randomly pick a point within the spawn object
	var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

	// Create an enemy at the 'spawnPoint' position
	Instantiate(symbolPiece, spawnPoint, Quaternion.identity);
}