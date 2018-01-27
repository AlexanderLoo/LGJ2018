using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

	const string INICIOPINTADOVERDE = "<color=#008000ff>";
	const string FINPINTADO = "</color>";
	public InputField cuadroDeTexto; //Input field para escribir
	public string[] dialogoEl; //Lista de dialogos tuyos
	public string[] dialogoElla; //Lista de dialogos de ella

	public Text [] mostrarEl; // Lista de textos
	public Text [] mostrarElla; //lista de textos

	public Text [] textosColor;
	
	private string escribriCorrectamente;
	public Text mostrarCorrectamente;

	private string verificadorRepetir;

	public int [] cantidadTextoElla;
	
	
	private int inidiceDialogo; //Estado global del texto
	private int indiceTexto; //Indice de la letra del texto
	private int indiceDesfaseElla; //Inidce que arregla el desfase entre ella y tu


	private char[] letras;
	private bool espera;
	public bool terminarEscribirCorrectamente;

	public char[] listadoTexto; 
	public int _indiceListadoTexto;


	



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

		
		EscribriCorrectamente();
		return;


		
		 
		//Evita el contacto con el mouse
		if (Input.GetMouseButton(0)||Input.GetMouseButton(1) ||Input.GetMouseButton(2)||Input.GetMouseButton(3)||Input.GetMouseButton(4)||Input.GetMouseButton(5))
			return;

		// Verifica al precionar la tecla space
		if (Input.GetKeyDown (KeyCode.Space)){
			Tecleo (KeyCode.Space);
		
			return;
		}

		if (Input.GetKeyDown (KeyCode.Backspace)){
			BorrarTexto();
			return;
		}

		if (Input.anyKeyDown){
			if (Verificar())
				Tecleo(KeyCode.Print);
		}
	}
	
	string ObtenerValor (){
		string _valor = "";

		if (Input.GetKey(KeyCode.A))
			_valor = "A";

		else if (Input.GetKey(KeyCode.B))
			_valor = "B";
		
		else if (Input.GetKey(KeyCode.C))
			_valor = "C";

		else if (Input.GetKey(KeyCode.D))
			_valor = "D";
		
		else if (Input.GetKey(KeyCode.E))
			_valor = "E";

		else if (Input.GetKey(KeyCode.F))
			_valor = "F";
		
		else if (Input.GetKey(KeyCode.G))
			_valor = "G";

		else if (Input.GetKey(KeyCode.H))
			_valor = "H";
		
		else if (Input.GetKey(KeyCode.I))
			_valor = "I";
		
		else if (Input.GetKey(KeyCode.J))
			_valor = "J";
		
		else if (Input.GetKey(KeyCode.K))
			_valor = "K";

		else if (Input.GetKey(KeyCode.L))
			_valor = "L";
		
		else if (Input.GetKey(KeyCode.M))
			_valor = "M";
			
		else if (Input.GetKey(KeyCode.N))
			_valor = "N";
		
		else if (Input.GetKey(KeyCode.O))
			_valor = "O";

		else if (Input.GetKey(KeyCode.P))
			_valor = "P";
		
		else if (Input.GetKey(KeyCode.Q))
			_valor = "Q";

		else if (Input.GetKey(KeyCode.R))
			_valor = "R";
		
		else if (Input.GetKey(KeyCode.S))
			_valor = "S";

		else if (Input.GetKey(KeyCode.T))
			_valor = "T";
		
		else if (Input.GetKey(KeyCode.U))
			_valor = "U";
			
		else if (Input.GetKey(KeyCode.V))
			_valor = "V";

		else if (Input.GetKey(KeyCode.W))
			_valor = "w";

		else if (Input.GetKey(KeyCode.X))
			_valor = "X";

		else if (Input.GetKey(KeyCode.Y))
			_valor = "Y";
		
		else if (Input.GetKey(KeyCode.Z))
			_valor = "Z";
		else if (Input.GetKey(KeyCode.Space))
			_valor= " ";

		return _valor.ToLower();
	}

	private void EscribriCorrectamente (){
		if (terminarEscribirCorrectamente){
			listadoTexto = textosColor[0].text.ToCharArray(); 
			_indiceListadoTexto = 0;
			terminarEscribirCorrectamente = false;
		} 

		if (_indiceListadoTexto >= listadoTexto.Length )
			return;

		if (listadoTexto[_indiceListadoTexto].ToString().ToLower()==ObtenerValor()){
			if (_indiceListadoTexto ==0)
				escribriCorrectamente += listadoTexto[_indiceListadoTexto].ToString().ToUpper();
			else
				escribriCorrectamente += listadoTexto[_indiceListadoTexto];
			mostrarCorrectamente.text = INICIOPINTADOVERDE + escribriCorrectamente +FINPINTADO;
			_indiceListadoTexto++; 

		}

	}

	bool Verificar (){
		verificadorRepetir += ObtenerValor();
		char[] _cantidad = verificadorRepetir.ToCharArray();

		if (_cantidad.Length >= 4){
			

			if (_cantidad[0] == _cantidad[2] || _cantidad[1] == _cantidad[3]){
				if (_cantidad[_cantidad.Length-1] != _cantidad[3] && _cantidad[_cantidad.Length-1] != _cantidad[2] ){
					verificadorRepetir=""; 
					return true;
				} else 
					return false;
			}
			else
				verificadorRepetir=""; 
				return true;
		}
		return true;
	}
	private void Tecleo (KeyCode _tecla){
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
