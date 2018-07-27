using UnityEngine;
using System.Collections;

public class seguirpersonaje : MonoBehaviour {

	public Transform personaje;
	public float separacion =100f;


	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (personaje.position.x+separacion, personaje.transform.position.y+5, transform.position.z);
	
	}
}