using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	
	public static int a = 0;
	public static int block=1;
	// Use this for initialization
	void Start () {
		if (transform.eulerAngles.z == 0) {
			a++;
		}
		else {
			var str = gameObject.transform.name;
			string[]  strArr = str.Split(' ');
			if (strArr [0] == "Straight" && transform.eulerAngles.z == 180)
				a++;
		}

	}
	
	// Update is called once per frame
	void Update () {
		//if (a == 29)
			
	}
	void OnMouseDown() {
		if (block == 1) {
			float p = transform.eulerAngles.z;
			transform.Rotate (0, 0, 90);
			p = Mathf.Round (p);
			if (Mathf.Round (transform.eulerAngles.z) == 0) {
				a++;
			} else {
				var str = gameObject.transform.name;

				string[] strArr = str.Split (' ');
				if (strArr [0] == "Straight" && Mathf.Round (transform.eulerAngles.z) == 180)
					a++;
				else if (p == 0 || (strArr [0] == "Straight" && p == 180))
					a--;
			}
		}
		//print (a);
	}
}
