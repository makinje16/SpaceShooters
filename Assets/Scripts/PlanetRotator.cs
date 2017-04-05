using UnityEngine;
using System.Collections;

public class PlanetRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rotation = new Vector3 (5, 5, 0);
		gameObject.transform.Rotate (rotation * Time.deltaTime);
	}
}
