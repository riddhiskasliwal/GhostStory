#pragma strict
public var bullet : GameObject;
public var ahClip: AudioClip;
public var symbolCollectClip : AudioClip;
public var fireEffect: GameObject;
public static var life : int = 5;
public static var symbolPieces : int = 0;

function Start () {

}

function Update () {
	// GetAxis() returns a value between 1 and -1. Depending on which arrow key is pressed. So we change the spaceship X speed by GetAxis("Horizontal") * 10
	GetComponent.<Rigidbody2D>().velocity.x = Input.GetAxis("Horizontal") * 10; 
	// GetAxis() returns a value between 1 and -1. Depending on which arrow key is pressed. So we change the spaceship X speed by GetAxis("Horizontal") * 10
	GetComponent.<Rigidbody2D>().velocity.y = Input.GetAxis("Vertical") * 10; 

	// When the spacebar is pressed
	if (Input.GetKeyDown("space")) {
		// Create a new bullet at “transform.position” which is the current position of the ship
		Instantiate(bullet, transform.position, Quaternion.identity); 
	}
}

// Function called when the enemy collides with another object
function OnTriggerEnter2D(obj : Collider2D) {
	//Debug.Log();
	var name = obj.gameObject.name;

	// If it collided with a enemy
	if (name == "enemy(Clone)") {
		// And destroy the enemy
		Destroy(obj.gameObject); 
		Instantiate(fireEffect, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(ahClip, transform.position);
		if (life > 0) {
			life -= 1;
		}
	}

	//If it collided with a ghost beam
	if (name == "ghostBeam(Clone)") {
		// And destroy the ghost beam
		Destroy(obj.gameObject); 
		Instantiate(fireEffect, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(ahClip, transform.position);
		if (life > 0) {
			life -= 1;
		}
	}

	// If it collided with the symbol piece
	if (name == "symbolPiece(Clone)") {
		AudioSource.PlayClipAtPoint(symbolCollectClip, transform.position);
		// Destroy the symbol piece
		Destroy(obj.gameObject); 
		if (symbolPieces < 5) {
			symbolPieces += 1;
		}
	}
}

function OnGUI() {
	GUI.color = Color.red;
	GUI.Label(new Rect(20, 15, 400, 400), "<b>Life: " + life +"</b>");
	GUI.Label(new Rect(20, 35, 400, 400), "<b>Symbol Pieces: " + symbolPieces + "/5</b>");
}