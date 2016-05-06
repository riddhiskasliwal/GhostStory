 using UnityEngine;
 using System.Collections;
 
 public class Enemy : MonoBehaviour {
 
     public Transform target;
     public float speed = 4f;
     public AudioClip hurtByGhost; 
 
 
     void Start () {}
 
     void Update(){
     	transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime * .2f);
     }
     //handles colision between the player and the enemies
     void OnTriggerEnter2D(Collider2D obj ){
		string other = obj.gameObject.name;
		if (other == "Player") {
			UpperBar.health -= 5;
			AudioSource.PlayClipAtPoint(hurtByGhost, transform.position);
		}
	}
 
 }