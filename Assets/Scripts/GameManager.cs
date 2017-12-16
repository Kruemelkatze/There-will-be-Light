using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject checkpoint;
    

	// Use this for initialization
	void Start () {
        generateLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void generateLevel(){
        generateCheckpoint();
    }

    void generateCheckpoint()
    {
        Instantiate(checkpoint, new Vector3(0.25f, 4, 0), Quaternion.identity);
    }

}
