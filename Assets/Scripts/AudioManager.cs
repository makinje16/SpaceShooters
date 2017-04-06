using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour {

	public AudioSource audio;
	bool change = false;
	// Use this for initialization
	void Start () {

	}

	public void playGunShot(){
		print ("GunShot");
		audio.Play();
		change = true;
	}

	void CheckChange(){
		if (!audio.isPlaying && change == true) {
			SceneManager.LoadScene ("Game");
		} else {
			return;
		}
	}
	// Update is called once per frame
	void Update () {
		CheckChange ();
	}
}
