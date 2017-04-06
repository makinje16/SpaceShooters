using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {


    public GameObject musicPlayer;
    void Awake()
    {
        //When the scene loads it checks if there is an object called "MUSIC".
        musicPlayer = GameObject.Find("Background Music");
        if (musicPlayer == null)
        {
            
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
