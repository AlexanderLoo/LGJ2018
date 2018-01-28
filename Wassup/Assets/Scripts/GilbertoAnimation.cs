using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GilbertoAnimation : MonoBehaviour {

	private Image image;

	public Sprite[] idleImages;
	public Sprite[] actionImages;
	//velocidad en segundos
	public float speed = 0.5f;
	public bool action;
	private float timer;
	private int index;

	void Awake(){
		image = GetComponent<Image> ();
	}
	void Start(){

		timer = speed;
		StartCoroutine (Flipping ());
	}

	void Update(){
		Flipping ();
		if (action) {
			AnimationManager (actionImages);
		} else {
			AnimationManager (idleImages);
		}
	}

	void AnimationManager(Sprite[]spriteList){

		timer -= Time.deltaTime;
		if (timer <= 0) {
			timer = speed;
			image.sprite = spriteList [index];
			if (index < spriteList.Length - 1) {
				index++;
			} else {
				index = 0;
			}
		}
	}

	IEnumerator Flipping(){

		while (true) {
			yield return new WaitForSeconds (3);
			RandomScale ();
		}
	}
	//Función para flipear el personaje
	void RandomScale(){

		int[] i = { -1, 1 };
		int random = Random.Range (0, 2);
		Vector3 newScale = transform.localScale;
		newScale.x = i [random];
		transform.localScale = newScale;
	}

}
