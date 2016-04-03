#pragma strict

// player's weapons
public var bullet : GameObject; 

// how often to randomize whether to reverse the direction
public var jumbleTime : float = 5;

// variables to store whether the horizontal or vertical movement is reverse to the input
var reverseX : float = 1;
var reverseY : float = 1;

function Start () { 
	// every jumbleTime seconds, determine whether or not to reverse X or Y input
	InvokeRepeating("whetherReverse", jumbleTime, jumbleTime);
} 

function Update () {
// Move the player horizontally and vertically
	GetComponent.<Rigidbody2D>().velocity.x = Input.GetAxis("Horizontal") * 10 * reverseX; 
	GetComponent.<Rigidbody2D>().velocity.y = Input.GetAxis("Vertical") * 10 * reverseY; 

	// When the spacebar is pressed
	if (Input.GetKeyDown("space")) { // Create a new bullet at “transform.position” which is the current position of the ship
		Instantiate(bullet, transform.position, Quaternion.identity); 
	}
}

function whetherReverse () {
	// randomly reverse X or Y movement (reverseX or reverseY will be -1 or 1)
	reverseX = Mathf.Pow(-1, Mathf.Round(Random.value));
	reverseY = Mathf.Pow(-1, Mathf.Round(Random.value));
}