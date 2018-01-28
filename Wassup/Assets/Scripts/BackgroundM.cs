using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundM : MonoBehaviour 
{

	// Use this for initialization
	public float forcex;
	public GameObject player;
	public float forcey;
	private Rigidbody2D body;
	string password="pokemon";
	public static bool Mover;

	void Start () 
	{
		body = GetComponent<Rigidbody2D> ();
		Mover = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Mover) 
		{
			float forceX = 0;
			float forceY = 0;
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
				forceX = -forcex;
				player.transform.rotation = Quaternion.Euler (0, 0, 90);
			}
			if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
				forceX = forcex;
				player.transform.rotation = Quaternion.Euler (0, 0, 270);
			}
			if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
				forceY = forcey;
				player.transform.rotation = Quaternion.Euler (0, 0, 0);
			}
			if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
				forceY = -forcey;
				player.transform.rotation = Quaternion.Euler (0, 0, 180);
			}
			body.velocity = new Vector2 (forceX, forceY);
		}
	}
}
