using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float padding = 1f;
	public static float health = 100;
	public GameObject projectile;
	Animator anim;
	Animation hit;
	float xmin;
	float xmax;
	public AudioSource audio;
	public AudioSource death;
	// Use this for initialization
	void Start () {
		hit = GetComponent<Animation> ();
		anim = GetComponent<Animator> ();
		float zed = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,zed));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,zed));
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;

	}

	void movement(){

		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * Time.deltaTime * speed;
			}
		if (Input.GetKey (KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * Time.deltaTime * speed;
		}
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, 0);
	}

	void checkShoot(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector3 position = new Vector3 (transform.position.x, transform.position.y + .6648f, 0);
			GameObject bullet = Instantiate (projectile, position, Quaternion.identity) as GameObject;
			bullet.tag = "PlayerLaser";
			audio.Play ();
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "EnemyLaser") {
			health -= 10;
			hit.Play ();
			if (health < 30) {
				hit.wrapMode = WrapMode.Loop;
			}
		}
		if (coll.tag == "HealthPickup") {
			health = 100;
			GameObject.Destroy (coll.gameObject);
		}
	}

	void checkDeath(){
		if (health <= 0) {
			//death.Play ();
			GameObject.Destroy (gameObject);
			SceneManager.LoadScene ("Lose");
            PlayerController.health = 100;
		}
	}
		

	// Update is called once per frame
	void Update () {
		movement ();
		checkShoot ();
		checkDeath ();
		if (health > 30 && hit.wrapMode == WrapMode.Loop) {
			hit.wrapMode = WrapMode.Default;
		}
	}
}
