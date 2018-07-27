using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enAI2 : MonoBehaviour {
	Transform tr_Player;
	float f_RotSpd = 3.0f, f_mvSpd = 3.0f;
	void Start(){
		tr_Player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	void Update(){
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position), f_RotSpd * Time.deltaTime);

		transform.position += transform.forward * f_mvSpd * Time.deltaTime;
	}

}
