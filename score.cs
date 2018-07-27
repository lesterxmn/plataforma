using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

	public Text puntaje;

	void Start () {
		puntaje.text = "puntaje : "+cuadroMove.punGlobal;
	}

	void Update(){
		puntaje.text = "puntaje : "+cuadroMove.punGlobal;
	}

}
