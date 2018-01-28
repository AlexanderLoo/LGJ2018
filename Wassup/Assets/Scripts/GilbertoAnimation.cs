using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GilbertoAnimation : MonoBehaviour {

	private Image image;

	public Image[] idleImages;
	public Image[] actionImages;
	//velocidad en segundos
	public float speed = 0.5f;
	public bool action;
	private float timer;
	private int index;

	void Start(){

		timer = speed;
	}

	void Update(){
		if (action) {
			AnimationManager (actionImages);
		} else {
			AnimationManager (idleImages);
		}
	}

	void AnimationManager(Image[]imageList){

		timer -= Time.deltaTime;
		if (timer <= 0) {
			timer = speed;
			image = imageList [index];
			if (index < imageList.Length - 2) {
				index++;
			} else {
				index = 0;
			}
		}
	}

}
