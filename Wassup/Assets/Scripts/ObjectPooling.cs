using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour {

	public static ObjectPooling instance;

	public GameObject _prefab;
	public GameObject[] poolList;
	public int poolAmount = 30;

	void Awake(){

		instance = this;
	}

	void Start(){

		poolList = new GameObject [poolAmount];
		for (int i = 0; i < poolList.Length; i++) {
			GameObject obj = (GameObject)Instantiate (_prefab);
			obj.SetActive (false);
			poolList [i] = obj;
		}
	}

	public GameObject ActiveGameObject(RectTransform parent,Vector3 pos){

		for (int i = 0; i < poolAmount; i++) {

			if (!poolList[i].activeSelf) {
				poolList[i].transform.parent = parent;
				poolList [i].GetComponent<RectTransform> ().localPosition = pos;
				poolList [i].SetActive (true);
				return poolList [i];
			}
		}
		return null;
	}
}
