using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

	public float speed;
	Vector3 direction;
	// Use this for initialization
	void Start () {
		if (gameObject.tag == "EnemyLaser") {
			direction = Vector3.down;
		}
		if(gameObject.tag == "PlayerLaser"){
			direction = Vector3.up;
			gameObject.transform.parent = null;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (transform.tag == "PlayerLaser") {
			if (collider.gameObject.tag == "Enemy") {
				GameObject.Destroy (collider.transform.parent.gameObject);
				GameObject.Destroy (collider.gameObject);
				GameObject.Destroy (gameObject);
			}
		}
		if (gameObject.tag == "EnemyLaser") {
			if (collider.gameObject.tag == "Player") {
				Debug.Log ("Hit Player");
			}
		}
			
	}

	void checkDestroy(){
		if (gameObject.transform.position.y > 6) {
			GameObject.Destroy (gameObject);
		}
		if (gameObject.tag == "EnemyLaser" && gameObject.transform.position.y < -6) {
			GameObject.Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction * Time.deltaTime * speed;
		checkDestroy ();
	}
}
