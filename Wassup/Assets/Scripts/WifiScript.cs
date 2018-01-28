using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifiScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "wifi") {
			Destroy (other.gameObject);
		} 
		else if 
		(other.gameObject.tag == "win") 
		{
			print ("ganaste");
		}
	}
}
