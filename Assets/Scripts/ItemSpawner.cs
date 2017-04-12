using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject health;
	public GameObject player;
	bool spawnHealth;
	public static int count;
	void Start () {
		count = 0;
		spawnHealth = false;
	}

	void checkSpawn(){
		if (gameObject.transform.childCount == 0) {
			spawnHealth = false;
		}
	}
	// Update is called once per frame
	void Update () {
		
		if (count == 1800 && spawnHealth == false) {
			System.Random rand = new System.Random ();
			float x = rand.Next (-11, 12);
			Vector3 spawn = new Vector3 (x, player.transform.position.y, 0);
			GameObject healthObject = Instantiate (health, spawn, Quaternion.identity) as GameObject;
			healthObject.transform.parent = transform;
			spawnHealth = true;;
		}
		checkSpawn ();
		count++;
		Debug.Log (count);
	}
}
