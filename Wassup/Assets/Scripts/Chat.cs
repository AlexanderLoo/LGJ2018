using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

	const string INICIOPINTADOVERDE = "<color=#008000ff>";
	const string FINPINTADO = "</color>";
	public enum Estado {
		tapear,
		exacto,
		completar,
		anagrama,
		memoria
	};
	public Estado estado;
	public InputField cuadroDeTexto; //Input field para escribir
	public string[] dialogoEl; //Lista de dialogos tuyos
	public string[] dialogoElla; //Lista de dialogos de ella

	public string[] palabrasCompletar;
	public string [] palabrasAnagramas;
	public string [] mensajeErrores;

	public GameObject el;
	public GameObject ella;
	public RectTransform posTexto;
	public Transform padreTextos;
	public Text textosColor;
	public Text anagrama; 
	private string escribriCorrectamente;
	public Text mostrarCorrectamente;
	private string verificadorRepetir;
	public int [] cantidadTextoElla;
	public int inidiceDialogo; //Estado global del texto
	private int indiceTexto; //Indice de la letra del texto
	private int indiceDesfaseElla; //Inidce que arregla el desfase entre ella y tu
	private int indiceAnagrama;
	public string verificadorTexto;
	private int indiceLetraAnagrama;
	private int indiceCompletarPalabra;
	private int indiceLetraCompletarPalabra;
	private char[] letras;
	public bool ellaEmpieza;
	private bool espera;
	private bool terminarEscribirCorrectamente = true;
	private bool crearAnagrama = true;
	private char[] listadoLetrasCompletar;
	private char[] listadoTexto; 
	private int _indiceListadoTexto;
	
	// Use this for initialization
	void Start () {
		indiceTexto = 0;
		if (ellaEmpieza){
			StartCoroutine (MensajesSeguidos(0.3f,cantidadTextoElla[0]));
			espera = true;
			
		} else {
		espera = false;

		}
		letras  = dialogoEl[inidiceDialogo].ToCharArray();
	}
	
	// Update is called once per frame
	void Update () {


		if (espera)
			return;

		if (inidiceDialogo>= dialogoEl.Length || inidiceDialogo>= cantidadTextoElla.Length )
			return;

		switch (cantidadTextoElla[inidiceDialogo])
		{
			case 10: estado = Estado.tapear; break;
			case 20: estado = Estado.exacto;  break;
			case 30: estado = Estado.completar;  break;
			case 40: estado = Estado.anagrama;  break;
			case 50: estado = Estado.memoria;  break;							
		}

		switch (estado.ToString())
		{			
			case "tapear":
				textosColor.enabled = false;
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
			break;

			case "exacto":
				verificadorTexto = dialogoEl[inidiceDialogo];
				textosColor.text = dialogoEl[inidiceDialogo];		
				cuadroDeTexto.text = " ";
				EscribriCorrectamente();

				if (Input.GetKeyDown(KeyCode.Return))
					EnviarTexto();
				
			break;
			case "completar":
				textosColor.text = dialogoEl[inidiceDialogo];		
				cuadroDeTexto.text = " ";
				EscribriCorrectamente();

				if (Input.GetKeyDown(KeyCode.Return)){
					EnviarTexto();
					indiceCompletarPalabra++;
				}
			break;

			case "anagrama":
				if (crearAnagrama){
					anagrama.enabled = true;
					textosColor.enabled = true;
					verificadorTexto = palabrasAnagramas[indiceAnagrama];
					anagrama.text = palabrasAnagramas[indiceAnagrama].Anagram();
					crearAnagrama = false;
					cuadroDeTexto.text = " ";
				}

				if (Input.GetKeyDown(KeyCode.Return)){
					CrearTexto (el,70f,mostrarCorrectamente.text);
					if (verificadorTexto  != mostrarCorrectamente.text){
						CrearTexto(ella,-70,mensajeErrores[Random.Range(0,mensajeErrores.Length)]);
						}
					inidiceDialogo++;
					textosColor.enabled = false;
					terminarEscribirCorrectamente = true;
					mostrarCorrectamente.text = "";
					indiceAnagrama++;
					anagrama.enabled = false;
				}
				
				if (indiceLetraAnagrama >= palabrasAnagramas[indiceAnagrama].Length)
					return;

				if (palabrasAnagramas[indiceAnagrama][indiceLetraAnagrama].ToString() == ObtenerValor()){
					mostrarCorrectamente.text += palabrasAnagramas[indiceAnagrama][indiceLetraAnagrama];
					indiceLetraAnagrama++;
				}


			break;

			case "memoria":
				verificadorTexto = dialogoEl[inidiceDialogo];
				textosColor.text = dialogoEl[inidiceDialogo];		
				cuadroDeTexto.text = " ";
				EscribriCorrectamente();
				if (Input.GetKeyDown(KeyCode.Return))
					EnviarTexto();
			break;
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

	private void EnviarTexto (){
		CrearTexto (el,70f,escribriCorrectamente);
				
		if (verificadorTexto  != escribriCorrectamente){
			CrearTexto(ella,-70,mensajeErrores[Random.Range(0,mensajeErrores.Length)]);
		}

		inidiceDialogo++;
		letras  = dialogoEl[inidiceDialogo].ToCharArray();
		textosColor.enabled = false;
		terminarEscribirCorrectamente = true;
		mostrarCorrectamente.text = "";
		textosColor.text = "";
		escribriCorrectamente = "";
		


	}
	private void EscribriCorrectamente (){
		if (terminarEscribirCorrectamente){
			textosColor.enabled = true;
			if (estado == Estado.memoria)
				StartCoroutine(Memoria());
			listadoTexto = textosColor.text.ToCharArray();
			listadoLetrasCompletar = palabrasCompletar[indiceCompletarPalabra].ToCharArray();
			indiceLetraCompletarPalabra=0;
			_indiceListadoTexto = 0;
			terminarEscribirCorrectamente = false;
		} 

		if (_indiceListadoTexto >= listadoTexto.Length )
			return;

		if (listadoTexto[_indiceListadoTexto] == '-'){
			if (listadoLetrasCompletar[indiceLetraCompletarPalabra].ToString() == ObtenerValor()){
				escribriCorrectamente += listadoLetrasCompletar[indiceLetraCompletarPalabra];
				mostrarCorrectamente.text = INICIOPINTADOVERDE + escribriCorrectamente +FINPINTADO;
				_indiceListadoTexto++; 
				indiceLetraCompletarPalabra++;
				return;
			}
			else 
				return;

		}

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
			cuadroDeTexto.text += letras[indiceTexto];
			indiceTexto++;  
		} else {
			TerminarTexto();			
		}
	}
	
	private void TerminarTexto (){
		espera = true;
		StartCoroutine(EsperarEntreMensajes(1.3f,cantidadTextoElla[inidiceDialogo]));
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
				CrearTexto (ella,-70f,dialogoElla[inidiceDialogo+indiceDesfaseElla]);
			
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
		CrearTexto (el,70f,cuadroDeTexto.text);
		BorrarTexto();
		yield return new WaitForSeconds (_tiempo);

			if (_repetir >= 2){
				StartCoroutine (MensajesSeguidos(0.5f,_repetir));
			} else if (_repetir == 1){
				if (inidiceDialogo < dialogoEl.Length)
					CrearTexto (ella,-70f,dialogoElla[inidiceDialogo+indiceDesfaseElla]);
				
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

	private void CrearTexto (GameObject _objeto, float _desfase, string _texto){
		GameObject _nuevoTextoElla = Instantiate (_objeto,posTexto.anchoredPosition,transform.rotation);
		_nuevoTextoElla.transform.SetParent(padreTextos);
		_nuevoTextoElla.GetComponent<RectTransform>().anchoredPosition = new Vector3 (_desfase,posTexto.anchoredPosition.y,0f);
		_nuevoTextoElla.GetComponentInChildren<Text>().text = _texto;
		posTexto.anchoredPosition = new Vector3 (posTexto.anchoredPosition.x,posTexto.anchoredPosition.y-50f);
		if (posTexto.anchoredPosition.y <= -280)
			padreTextos.GetComponent<RectTransform>().anchoredPosition = new Vector3 (0,padreTextos.GetComponent<RectTransform>().anchoredPosition.y+50f,0 );
		estado = Estado.tapear;
	}
	IEnumerator Memoria (){
		yield return new WaitForSeconds (2f);
		textosColor.enabled = false;	
	}
}
