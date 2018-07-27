 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movplat : MonoBehaviour {
	
	void OnCollisionEnter(Collision col){
		col.transform.parent = gameObject.transform;
	}

	void OnCollisionExit(Collision col){
		col.transform.parent = null;
	}

}
