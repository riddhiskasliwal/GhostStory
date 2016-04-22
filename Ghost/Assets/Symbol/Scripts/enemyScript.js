#pragma strict
public var fireEffect: GameObject;
public var boomClip: AudioClip;
public var speed : int = -5;
public static var score : int = 10;

// Function called when the enemy is created
function Start () {
	// Add a vertical speed to the enemy
	GetComponent.<Rigidbody2D>().velocity.y = speed;

	// Destroy the enemy in 3 seconds, when it is no longer visible on the screen
	Destroy(gameObject, 3);
}

// Function called when the enemy collides with another object
function OnTriggerEnter2D(obj : Collider2D) {
	var name = obj.gameObject.name;

	// If it collided with a bullet
	if (name == "bullet(Clone)") {
		// Destroy itself (the enemy)
		Destroy(gameObject);
		// And destroy the bullet
		Destroy(obj.gameObject); 
		Instantiate(fireEffect, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint(boomClip, transform.position);
		score += 10;
	}
}

function OnGUI() {
	GUI.color = Color.red;
	GUI.Label(new Rect(20, 55, 400, 400), "Score: " + score);
}