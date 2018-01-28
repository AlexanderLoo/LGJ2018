using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;



public class WifiScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "wifi") 
		{
			Destroy (other.gameObject);
		} 

		else if 
		(other.gameObject.tag == "corazon") 
		{
			var pixelater = new PixelateTransition()
			{
				nextScene = 2,
				finalScaleEffect = PixelateTransition.PixelateFinalScaleEffect.ToPoint,
				duration = 1.0f
			};
			TransitionKit.instance.transitionWithDelegate( pixelater );
		}
	}
}
