using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {


    public GameObject musicPlayer;
	private static BackgroundMusic _instance;
		// Use this for initialization

		void Awake(){
			//if we don't have an [_instance] set yet
			if(!_instance)
				_instance = this;
			//otherwise, if we do, kill this thing
			else
				Destroy(this.gameObject) ;


		DontDestroyOnLoad (this.gameObject);
		}

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
