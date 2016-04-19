#pragma strict

var Player : Transform;
var MoveSpeed = 3;
var MaxDist = 10;
var MinDist = 0;

function Start () {}

function Update () {
	transform.position = Vector2.MoveTowards(transform.position, Player.position, MoveSpeed * 0.2 * Time.deltaTime);
}