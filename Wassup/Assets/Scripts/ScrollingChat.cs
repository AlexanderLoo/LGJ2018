using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingChat : MonoBehaviour {

	private RectTransform _transform;
	public float maxInY = 2000;

	void Start(){

		_transform = GetComponent<RectTransform> ();
	}

	void Update(){

		_transform.Translate (Vector3.up * 10);
		Reposition ();
	}

	void Reposition(){

		if (_transform.position.y >= maxInY) {
			Vector3 newPosition = _transform.position;
			newPosition.y -= _transform.sizeDelta.y * 2;
			_transform.position = newPosition;
		}
	}
}
