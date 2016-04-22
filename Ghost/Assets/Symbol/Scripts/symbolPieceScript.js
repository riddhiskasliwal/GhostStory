#pragma strict
public var fireEffect: GameObject;
public var myClip: AudioClip;
public var speed : int = -5;

// Function called when the enemy is created
function Start () {
	// Add a vertical speed to the enemy
	GetComponent.<Rigidbody2D>().velocity.y = speed;

	// Make the enemy rotate on itself
	GetComponent.<Rigidbody2D>().angularVelocity = Random.Range(-200, 200);

	// Destroy the enemy in 3 seconds, when it is no longer visible on the screen
	Destroy(gameObject, 3);
}

// Function called when the enemy collides with another object
function OnTriggerEnter2D(obj : Collider2D) {
	var name = obj.gameObject.name;

	// If it collided with a bullet
	if (name == "bullet(Clone)") {
		// Destroy itself (the symbol piece)
		Destroy(gameObject);
		// And destroy the bullet
		Destroy(obj.gameObject); 
		Instantiate(fireEffect, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(myClip, transform.position);
	}
}