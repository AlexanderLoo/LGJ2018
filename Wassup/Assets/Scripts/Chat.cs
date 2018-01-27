using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

	public InputField cuadroDeTexto;
	public string texto;
	private string nuevoTexto;
	public int indice;

	char[] letras;
	// Use this for initialization
	void Start () {
		indice = 0;
		letras  = texto.ToCharArray();
	}
	
	// Update is called once per frame
	void Update () {
		 
		if (Input.GetKeyDown (KeyCode.Space)){
			Verificar (KeyCode.Space);
			return;
		}

		if (Input.GetKeyDown (KeyCode.Backspace)){
			cuadroDeTexto.text = "";
			indice = 0;
			return;

		}

		if (Input.anyKeyDown)
			Verificar(KeyCode.Print);
		

	}


	public void Verificar (KeyCode _tecla){
		
		if (indice < letras.Length){

			if (letras[indice] == ' '){
				if (_tecla.ToString () != "Space")
					return;    
			}

			cuadroDeTexto.text += letras[indice];
			indice++;  
		}
	}
}
