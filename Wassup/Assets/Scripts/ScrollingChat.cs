using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingChat : MonoBehaviour {

	private RectTransform _transform;
	//Máximo en Y para cambiar de posición 
	public float maxInY = 2000;
	public float moveInYAmount = 10;

	void Start(){

		_transform = GetComponent<RectTransform> ();
	}

	void Update(){

		Reposition ();
		MovingScroll ();
	}

	void Reposition(){

		if (_transform.position.y >= maxInY) {
			Vector3 newPosition = _transform.position;
			newPosition.y -= _transform.sizeDelta.y * 2;
			_transform.position = newPosition;
		}
	}

	void MovingScroll(){

		//Solo para testeo
		if (Input.GetKeyDown(KeyCode.Space)) {
			_transform.Translate (Vector3.up * moveInYAmount);
		}
	}
}
