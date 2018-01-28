using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NoviaSpawn : MonoBehaviour {

	public GameObject[] pos;
	public GameObject novia;
	// Use this for initialization
	void Start () 
	{
		Instantiate (novia, pos [Random.Range (0, pos.Length)].transform.position, transform.rotation,gameObject.transform);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
