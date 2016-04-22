#pragma strict
public var speed : float = 0.5;
public var ghostLaughClip: AudioClip;
public var laserClip: AudioClip;

function Start () {
	// Add a vertical speed to the enemy
	GetComponent.<Rigidbody2D>().velocity.x = speed;
	yield WaitForSeconds(2);
	AudioSource.PlayClipAtPoint(ghostLaughClip, transform.position);
	GetComponent.<Rigidbody2D>().velocity.x = 0;
	yield WaitForSeconds(3);
	AudioSource.PlayClipAtPoint(laserClip, transform.position);
	Destroy(gameObject, 0);
}