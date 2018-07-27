using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cuadroMove : MonoBehaviour {
	public Transform plyr;
	public float vel = 10f;
	public float saltura = 500f;
	private bool enSuelo;
	private bool vivo;
	public Transform wrp;
	public Text gover;
	public Button rest;

	public GameObject bala;
	public static float velBala = 3;
	public Transform fusca;
	public GameObject enemy;
	public AudioClip jmpsfx;
	public AudioClip gunsfx;
	public AudioClip bzsfx;
	private AudioSource vocina;

	public GameObject newWeapon;
	public float fireRate;
	private float nextFire;

	public static int punGlobal = 0;

	void Start(){
		enSuelo = true;
		newWeapon.gameObject.SetActive (false);
		vocina = GetComponent<AudioSource>();
		gover.gameObject.SetActive (false);
		vivo = true;
	}

	void Update (){
		
		if(Input.GetButton("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			vocina.PlayOneShot(gunsfx, 0.7F);
			GameObject clone =  Instantiate(bala) as GameObject;
			clone.transform.position = transform.position + fusca.transform.right;
			Rigidbody rb = clone.GetComponent<Rigidbody> ();
			rb.velocity = fusca.transform.right * velBala;
			Destroy (clone.gameObject, 2);
		}

		if (Input.GetKey(KeyCode.A)){
			transform.position += Vector3.left * vel * Time.deltaTime;
			transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
		}

		if (Input.GetKey(KeyCode.D)){
			transform.position += Vector3.right * vel * Time.deltaTime;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		}

		if(enSuelo){
			if (Input.GetKeyDown (KeyCode.Space) && enSuelo) {
				this.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * saltura);
				vocina.PlayOneShot(jmpsfx, 0.7F);
				enSuelo = false;
			} 
		}

		if (Input.GetKeyDown(KeyCode.End)){
			Debug.Log ("Restart");
		}

		if (vivo) {
			this.gameObject.SetActive (true);
		} else {
			StartCoroutine ("Gover");
		}

	}

	void OnCollisionEnter(Collision toca){
		if(toca.gameObject.CompareTag("suelo")){
			enSuelo = true;
		}

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("item")) {
			other.gameObject.SetActive (false);
			//Destroy (other.gameObject);
			punGlobal += 1;
		} 
		if(other.gameObject.CompareTag("ehead")){
			enemy.gameObject.SetActive (false);
			punGlobal += 1;
		}
		if (other.gameObject.CompareTag("ebody")){
			//Destroy (plyr.gameObject);
			rest.gameObject.SetActive (true);
			gover.gameObject.SetActive (true);
			punGlobal = 0;
			vivo = false;
		}
		if (other.gameObject.CompareTag ("nweapon")) {
			other.gameObject.SetActive (false);
			velBala = 30f;
			newWeapon.gameObject.SetActive (true);
			//Destroy (wpclone.gameObject, 2);
		}
		if(other.gameObject.CompareTag ("deadzone")){
			newWeapon.gameObject.SetActive (false);
		}
		if(other.gameObject.CompareTag("warp")){
			transform.position = wrp.transform.position;
		}
	}

	public void RestartGame(){
		SceneManager.LoadScene ("main");
	}

	IEnumerator Gover(){		
		yield return new WaitForSeconds (2);
		vivo = true;
		SceneManager.LoadScene ("main");
		Debug.Log ("Return");
	}
}