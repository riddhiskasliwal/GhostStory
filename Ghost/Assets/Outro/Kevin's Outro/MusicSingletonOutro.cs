using UnityEngine;
using System.Collections;

public class MusicSingletonOutro : MonoBehaviour {

	public static MusicSingletonOutro instance;
	void  Awake (){
		if ( instance != null && instance != this ) 
		{
			Destroy( this.gameObject );
			return;
		} 
		else 
		{
			instance = this;
		}

		DontDestroyOnLoad( this.gameObject );
	}

	public static MusicSingletonOutro GetInstance (){
		return instance;
	}
}
