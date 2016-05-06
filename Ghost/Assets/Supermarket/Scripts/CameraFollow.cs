using UnityEngine;
using System.Collections;

//This script is used throught the game. This alows the camera to follow the player. 
public class CameraFollow : MonoBehaviour {

	public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
	public float camera_y = 0.2f;
    // Update is called once per frame
    void Update () 
    {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, camera_y, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}