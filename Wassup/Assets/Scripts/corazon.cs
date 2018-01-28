using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corazon : MonoBehaviour {

	public Transform heart;
	public GameObject creditos;
	public bool agrandar;

	// Use this for initialization
	void Start () {
		Invoke("Active",5)	;
		}

	
	// Update is called once per frame
	void Update () {


		if (heart.localScale.x < 1.0f) {
			agrandar = true;
		}
		if (heart.localScale.x > 1.5f) {
			agrandar = false;
		}
		if (agrandar == true) {
				heart.localScale += new Vector3 (0.01F, 0.01F, 0);
			}

		if (agrandar == false) {
			heart.localScale -= new Vector3 (0.01F, 0.01F, 0);
		}
	}
	void Active() {
creditos.SetActive(true);

		
	}

}
