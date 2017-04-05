using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {
	
	public GameObject enemyPrefab;
	public GameObject projectile;
	void OnDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position,1);
	}

	void shoot(){
		Vector3 position = new Vector3 (transform.position.x, transform.position.y - .9f, 0f);
		GameObject bullet = Instantiate (projectile, position, Quaternion.identity) as GameObject;
		bullet.transform.tag = "EnemyLaser";
		bullet.transform.Rotate(new Vector3(0,0,180),Space.Self);
	}

	void Start(){
		GameObject enemy = Instantiate (enemyPrefab, gameObject.transform.position, Quaternion.identity) as GameObject; 
		enemy.transform.parent = transform;
		Vector3 rotation = new Vector3 (0, 0, -90);
		enemy.transform.Rotate (rotation);
	}



	void Update(){
		System.Random rand = new System.Random ();
		int x = rand.Next (1, 50);
		if (x == 25){
			shoot ();
		}
	}

}
