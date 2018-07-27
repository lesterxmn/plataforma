using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platAnima : MonoBehaviour {

	public Transform movPlat;
	public Transform posA;
	public Transform posB;
	public Vector3 newPos;
	public string currentState;
	public float smooth;
	public float resetTime;

	void Start () {
		ChangeTarget ();
	}
	

	void FixedUpdate () {
		//transform.position = new Vector3 (Mathf.PingPong(Time.time,3), transform.position.z*2, transform.position.z*2);
		//transform.position = Vector3.Lerp (transform.position, new Vector3(30,-2,0), Time.deltaTime);
		movPlat.position = Vector3.Lerp(movPlat.position, newPos, smooth * Time.deltaTime );
	}

	void ChangeTarget(){ 
		if(currentState == "Move 2 A"){
			currentState = "Move 2 B";
			newPos = posB.position;
		}
		else if(currentState == "Move 2 B"){
			currentState = "Move 2 A";
			newPos = posA.position;
		}
		else if(currentState == ""){
			currentState = "Move 2 B";
			newPos = posB.position;
		}
		Invoke ("ChangeTarget", resetTime);
	}

}
