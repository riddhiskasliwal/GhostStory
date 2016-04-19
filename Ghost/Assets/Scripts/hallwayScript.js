#pragma strict

function OnTriggerEnter (player : Collider) {
	if (player.tag == "Player") {
		Application.LoadLevel("Level2");
	}
}