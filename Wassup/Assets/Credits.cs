using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	public float speed;
	public float timeToChange= 10;

	void Start(){
		Invoke ("ChangeScene",timeToChange);

	}
	void Update(){

		transform.Translate (Vector2.up * speed);
	}

	void ChangeScene(){
		SceneManager.LoadScene ("MainMenu");
	}
}
