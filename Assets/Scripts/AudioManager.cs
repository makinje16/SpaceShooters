using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioSource gunShot;

	// Use this for initialization
	void Start () {
	
	}

	public void playGunShot(){
		gunShot.Play ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
