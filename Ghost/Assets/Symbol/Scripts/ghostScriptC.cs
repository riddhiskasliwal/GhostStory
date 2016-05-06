using UnityEngine;
using System.Collections;

public class ghostScriptC : MonoBehaviour {

	public AudioClip ghostLaughClip;
	public AudioClip laserClip;
	public float speed = 0.5f;
	private Rigidbody2D ghost;

	void Start () {
		ghost = GetComponent<Rigidbody2D>();
		ghost.velocity = new Vector2(speed, 0); 
		StartCoroutine(Coroutine());
	}

	IEnumerator Coroutine(){
		yield return new WaitForSeconds(2);
		AudioSource.PlayClipAtPoint(ghostLaughClip, transform.position);
		ghost.velocity = new Vector2(0, 0); 
		yield return new WaitForSeconds(3);
		AudioSource.PlayClipAtPoint(laserClip, transform.position);
		Destroy(gameObject, 2);
	}
}
