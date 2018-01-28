using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public Image[] wifiSignals;
	private int signalIndex;
	public Image heartFill;
	public Animator heartAnim, wifiAnim, gilbertoAnim, gilbertaAnim;

	[HideInInspector]
	public bool noSignal, gameOver;

	//Estados, si estan usando el chat o usando el mapa
	[HideInInspector]
	public bool chatScreen, mapScreen;

	//Las siguientes variables controlan el tiempo de reducción de cada UI
	[HideInInspector]
	public float timeForWifi, timeForLove;
	private float timer = 20;
	//Espaciado entre textos
	public float spaceInY = 350;
	public float aditionSpacing = 50;

	void Awake(){

		instance = this;
	}

	void Start(){

		timeForWifi = timer;
		timeForLove = timer;
	}
	void Update(){
		/*
		Vector3 newPos = new Vector3 (0, spaceInY, 0);
		//Función de testeo para probar la la funcion del ObjectPool
		if (Input.GetButtonDown("Jump")) {
			ObjectPooling.instance.ActiveGameObject (chatBackgrounds[0],newPos);
			spaceInY += aditionSpacing;
		}
		 */
		if (heartFill.fillAmount == 0) {
			print ("GameOver");
		}
		DecreseWifiSignal ();
		DecreseLove ();
	}
	//Función para remover la imagen de la señal wifi según su índice
	public void RemoveSignal(){

		if (signalIndex <= wifiSignals.Length) {
			wifiSignals [signalIndex].enabled = false;
			if (signalIndex != wifiSignals.Length - 1) {
				signalIndex++;
			} else {
				noSignal = true;
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
	//Función que maneja el corazón 	
	public void HeartFill(float i){

		heartFill.fillAmount += i;
	}

	//Reducimos la señal de wifi con el tiempo y dependiendo del estado
	void DecreseWifiSignal(){

		timeForWifi -= Time.deltaTime;
		if (timeForWifi <= 0) {
			wifiAnim.SetTrigger ("WifiBlinking");
			timeForWifi = timer;
			RemoveSignal ();
		}
	}
	//Reducimos el corazón con el tiempo y dependiendo del estado
	void DecreseLove(){

		timeForLove -= Time.deltaTime;
		if (timeForLove <= 0) {
			heartAnim.SetTrigger ("HeartDamage");
			gilbertaAnim.SetTrigger ("Angry");
			timeForLove = timer;
			HeartFill (-0.3f);
		}
	}
	//Funciones para mantener corazon latiendo
	public void AddLove(float i){

		timeForLove += i;
		print (timeForLove);
	}

	public void RemoveLove(float i){

		timeForLove -= i;
		print (timeForLove);
	}
}
