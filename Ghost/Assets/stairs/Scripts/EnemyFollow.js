#pragma strict

var Player : Transform;
var MoveSpeed = 3;

function Start () {}

function Update () {
	transform.position = Vector2.MoveTowards(transform.position, Player.position, MoveSpeed * 0.2 * Time.deltaTime);
}

function OnTriggerEnter2D(col : Collider2D) {
    if (col.gameObject.name == "Player") {
    	// add decrease health code
    	// col.GetComponent<Stair_Player_Movements>().Health -= 1;

    }
}