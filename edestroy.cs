using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class edestroy : MonoBehaviour {

	public Transform jugador;
	public Text puntaje;

	void OnTriggerEnter(Collider other){

		if(other.gameObject.CompareTag("bullets")){
			this.gameObject.SetActive(false);
			cuadroMove.punGlobal += 1;
		}

	}
	void Update(){
		puntaje.text = "puntaje : "+cuadroMove.punGlobal;
	}
}
