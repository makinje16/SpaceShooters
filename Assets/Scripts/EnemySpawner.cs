using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject formation;
	float min;
	float max;
	float padding = 5.29f;
	public int moveDown;
	Vector3 moveDirection;
	// Use this for initialization
	void Start () {
		moveDown = 0;
		float zed = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,zed));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, zed));

		min = leftmost.x + transform.position.x + padding;
		max = rightmost.x - transform.position.x - padding;
		System.Random rand = new System.Random ();
		int move = rand.Next (1, 3);
		if (move == 1) {
			moveDirection = Vector3.left;
		} else {
			moveDirection = Vector3.right;
		}
	}

	void move(){
		if (transform.position.x == max) {
			moveDirection = Vector3.left;
			moveDown++;
		}
		if (transform.position.x == min) {
			moveDirection = Vector3.right;
			moveDown++;
		}
		if (moveDown == 4) {
			Debug.Log ("In the if statement");
			Vector3 moveDownV = Vector3.down;
			gameObject.transform.position += (moveDownV);
			moveDown = 0;
		}
		transform.position += moveDirection * 5 * Time.deltaTime;
		float NewX = Mathf.Clamp(transform.position.x,min,max);
		transform.position = new Vector3(NewX,transform.position.y,0);
	}

	bool AllMembersDead(){
		if(transform.childCount == 0){
			return true;
		}else{
			return false;
		}
	}
		
	// Update is called once per frame
	void Update () {
		move ();
		if (AllMembersDead ()) {
			SceneManager.LoadScene ("Win");
		}
	}
}
