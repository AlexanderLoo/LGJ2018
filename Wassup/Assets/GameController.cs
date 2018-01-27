using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public RectTransform[] chatBackgrounds;
	public Image[] wifiSignals;
	private int signalIndex;
	public bool gameOver;
	//Espaciado entre textos
	public float spaceInY = 350;
	public float aditionSpacing = 50;

	void Awake(){

		instance = this;
	}

	void Update(){
		Vector3 newPos = new Vector3 (0, spaceInY, 0);
		//Función de testeo para probar la la funcion del ObjectPool
		if (Input.GetButtonDown("Jump")) {
			ObjectPooling.instance.ActiveGameObject (chatBackgrounds[0],newPos);
			spaceInY += aditionSpacing;
		}
	}
	//Función para remover la imagen de la señal wifi según su índice
	public void RemoveSignal(){

		if (signalIndex <= wifiSignals.Length) {
			wifiSignals [signalIndex].enabled = false;
			if (signalIndex != wifiSignals.Length - 1) {
				signalIndex++;
			} else {
				gameOver = true;
				print ("GameOver");
			}
		}
	}
	//Función para agregar señal
	public void AddSignal(){

		wifiSignals [signalIndex].enabled = true;
		if (signalIndex != 0) {
			signalIndex--;
		}
	}

}
