#pragma strict
public var speed : int = 2;

// Function called when the enemy is created
function Start () {
	// Add a vertical speed to the enemy
	GetComponent.<Rigidbody2D>().velocity.x = speed;

	// Destroy the enemy in 3 seconds, when it is no longer visible on the screen
	Destroy(gameObject, 15);
}