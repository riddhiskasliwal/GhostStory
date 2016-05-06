using UnityEngine;
using System.Collections;

public class ThemeMusicSingleton : MonoBehaviour {

	public static ThemeMusicSingleton instance;
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
		Debug.Log ("you are at" + level + "and levelComplete is: " + UpperBar.levelComplete);

		if (level == 10 || level == 13 || level >= 15) {
			Destroy (this.gameObject);
		} 
	}

	public static ThemeMusicSingleton GetInstance (){
		return instance;
	}
}
