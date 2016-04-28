using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (splashScreen());
	}
	
	IEnumerator splashScreen(){
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("StartMenu");
	}
}
