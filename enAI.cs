using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enAI : MonoBehaviour {

	public Transform PlyrTrgt;
	public Transform EnSpwnLoc;
	public Material[] EnMats;
	public Renderer EnRndr;
	public float enSpd;
	public float maxDist;
	public float minDist;


	void Start () {
		 
	}
	

	void Update () {
		transform.LookAt (EnSpwnLoc);
		EnRndr.sharedMaterial = EnMats[0];

		if(Vector3.Distance(transform.position, EnSpwnLoc.position)>= minDist){
			transform.position += transform.forward * enSpd * Time.deltaTime;
		}

		if(Vector3.Distance(transform.position, PlyrTrgt.position)<= minDist){
			transform.LookAt (PlyrTrgt);
			transform.position += transform.forward * enSpd * Time.deltaTime;
			EnRndr.sharedMaterial = EnMats[1];
		}
		
	}
}
