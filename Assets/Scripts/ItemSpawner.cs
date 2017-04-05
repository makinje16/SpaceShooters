using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject health;
	public GameObject player;
	bool spawnHealth;
	int count;
	void Start () {
		count = 0;
	}

	void checkSpawn(){
		if (gameObject.transform.childCount == 0) {
			spawnHealth = false;
			count = 0;
		}
	}
	// Update is called once per frame
	void Update () {
		checkSpawn ();
		if (count == 3600 && spawnHealth == false) {
			System.Random rand = new System.Random ();
			float x = rand.Next (-11, 12);
			Vector3 spawn = new Vector3 (x, player.transform.position.y, 0);
			GameObject healthObject = Instantiate (health, spawn, Quaternion.identity) as GameObject;
			healthObject.transform.parent = transform;
			spawnHealth = true;
			count = 0;
		}
		count++;
	}
}
