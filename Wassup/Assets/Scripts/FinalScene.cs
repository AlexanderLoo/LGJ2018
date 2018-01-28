using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour {

	private AudioSource _as;

	public GameObject credits;

	void Start(){

		_as = GetComponent<AudioSource> ();
	}

	public void PlayMusic(){

		_as.Play ();
	}

	public void ShowCredits(){

		credits.SetActive (true);
	}
}
