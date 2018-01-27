using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

	public InputField cuadroDeTexto; //Input field para escribir
	public string[] dialogoEl; //Lista de dialogos tuyos
	public string[] dialogoElla; //Lista de dialogos de ella

	public Text [] mostrarEl; // Lista de textos
	public Text [] mostrarElla; //lista de textos

	public int [] cantidadTextoElla;
	
	
	public int inidiceDialogo; //Estado global del texto
	public int indiceTexto; //Indice de la letra del texto
	public int indiceDesfaseElla; //Inidce que arregla el desfase entre ella y tu

	private char[] letras;
	private bool espera;

	// Use this for initialization
	void Start () {
		indiceTexto = 0;
		espera = false;
		letras  = dialogoEl[inidiceDialogo].ToCharArray();
	}
	
	// Update is called once per frame
	void Update () {
		if (espera)
			return;
		 
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
		/*
			if (letras[indiceTexto] == ' ')
				if (_tecla.ToString () != "Space")
					return;
		 */
			
			cuadroDeTexto.text += letras[indiceTexto];
			indiceTexto++;  
		} else {
			TerminarTexto();
			
		}
	}
	
	private void TerminarTexto (){
		espera = true;
		StartCoroutine(EsperarEntreMensajes(1.5f,cantidadTextoElla[inidiceDialogo]));
		//Debug.Log (cantidadTextoElla[inidiceDialogo]);
	}

	private void BorrarTexto (){
		cuadroDeTexto.text = "";
		indiceTexto = 0;
	}

	IEnumerator MensajesSeguidos (float _tiempo, int _repetir){
		int _valor = 0;

		while (_valor < _repetir){
			yield return new WaitForSeconds (_tiempo);
			if (inidiceDialogo < dialogoEl.Length)
				mostrarElla[inidiceDialogo+indiceDesfaseElla].text = dialogoElla[inidiceDialogo+indiceDesfaseElla];
			_valor ++;
			indiceDesfaseElla++;
		}
		indiceDesfaseElla--;
		inidiceDialogo++;
		espera = false;		
		if (inidiceDialogo < dialogoEl.Length)
			letras  = dialogoEl[inidiceDialogo].ToCharArray();
	}
	IEnumerator EsperarEntreMensajes (float _tiempo,int _repetir){
		mostrarEl[inidiceDialogo].text = cuadroDeTexto.text;
		BorrarTexto();
		yield return new WaitForSeconds (_tiempo);

			if (_repetir >= 2){
				StartCoroutine (MensajesSeguidos(0.5f,_repetir));
			} else if (_repetir == 1){
				if (inidiceDialogo < dialogoEl.Length)
					mostrarElla[inidiceDialogo+indiceDesfaseElla].text = dialogoElla[inidiceDialogo+indiceDesfaseElla];
				inidiceDialogo++;
				if (inidiceDialogo < dialogoEl.Length)
					letras  = dialogoEl[inidiceDialogo].ToCharArray();
				espera = false;			
				}  else if (_repetir == 0){
					indiceDesfaseElla--;
					inidiceDialogo++;
					if (inidiceDialogo < dialogoEl.Length)
						letras  = dialogoEl[inidiceDialogo].ToCharArray();
					espera = false;			
			}
	}
}
