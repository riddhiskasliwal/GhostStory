using UnityEngine;
using System.Collections;

public class IntroMusicSingleton : MonoBehaviour {

	public static IntroMusicSingleton instance;
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

	void OnLevelWasLoaded( int level )
	{
		if (level == 8) {
			Destroy (this.gameObject);
		}
	}

	public static IntroMusicSingleton GetInstance (){
		return instance;
	}
}
