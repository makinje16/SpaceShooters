using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	// Use this for initialization
	void Start () {
	
	}

	void getHealth(){
		text.text = "Health: " + PlayerController.health;
	}

	// Update is called once per frame
	void Update () {
		getHealth ();
	}
}
