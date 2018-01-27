using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	public RectTransform[] chatBackgrounds;

	void Update(){

		//Función de testeo para probar la la funcion del ObjectPool
		if (Input.GetButtonDown("Jump")) {
			ObjectPooling.instance.ActiveGameObject (chatBackgrounds[0],Vector3.zero);
		}
	}
}
