using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {
	
	public Transform jugador;
	public Transform rspawnloc;
	public Transform gitem;
	public GameObject[] oitem;
	public GameObject[] enemys;
	public GameObject nweap;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			jugador.transform.position = rspawnloc.transform.position;
			gitem.gameObject.SetActive (true);
			oitem [0].SetActive (true);
			oitem [1].SetActive (true);
			enemys [0].SetActive (true);
			nweap.gameObject.SetActive (true);
			cuadroMove.punGlobal = 0;
			cuadroMove.velBala = 3;
		}

		if(other.gameObject.CompareTag("bullets")){
			Destroy (other.gameObject);
		}

	}

}
