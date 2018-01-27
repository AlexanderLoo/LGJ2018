﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

	public InputField cuadroDeTexto;
	public string[] dialogoEl;
	public string[] dialogoElla;

	public Text [] mostrarEl;
	public Text [] mostrarElla;
	
	
	public int inidiceDialogo;
	public int indiceTexto;

	private char[] letras;

	// Use this for initialization
	void Start () {
		indiceTexto = 0;
		letras  = dialogoEl[inidiceDialogo].ToCharArray();
	}
	
	// Update is called once per frame
	void Update () {
		 
		//Evita el contacto con el mouse
		if (Input.GetMouseButton(0)||Input.GetMouseButton(1) ||Input.GetMouseButton(2)||Input.GetMouseButton(3)||Input.GetMouseButton(4)||Input.GetMouseButton(5))
			return;

		// Verifica al precionar la tecla space
		if (Input.GetKeyDown (KeyCode.Space)){
			Verificar (KeyCode.Space);
			return;
		}

		if (Input.GetKeyDown (KeyCode.Backspace)){
			BorrarTexto();
			return;

		}

		if (Input.anyKeyDown)
			Verificar(KeyCode.Print);
	
	}

	private void Verificar (KeyCode _tecla){
		if (inidiceDialogo >= dialogoEl.Length)
			return;

		if (indiceTexto < letras.Length){
			if (letras[indiceTexto] == ' ')
				if (_tecla.ToString () != "Space")
					return;
			
			cuadroDeTexto.text += letras[indiceTexto];
			indiceTexto++;  
		} else {
			TerminarTexto();
			
		}
	}
	
	private void TerminarTexto (){
		MostrarTexto();
		BorrarTexto();
		inidiceDialogo++;
		if (inidiceDialogo >= dialogoEl.Length)
			return;
		letras  = dialogoEl[inidiceDialogo].ToCharArray();
	}

	private void MostrarTexto(){
		mostrarEl[inidiceDialogo].text = cuadroDeTexto.text;
		mostrarElla[inidiceDialogo].text = dialogoElla[inidiceDialogo];

	}

	private void BorrarTexto (){
		cuadroDeTexto.text = "";
		indiceTexto = 0;
	}
}
