using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void LoadGame(){
		SceneManager.LoadScene ("Game");
	}

	public void LoadStart(){
		SceneManager.LoadScene ("Start");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
