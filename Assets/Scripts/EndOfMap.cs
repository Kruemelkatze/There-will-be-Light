using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfMap : MonoBehaviour {

    public Text lblHighScore;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Hub.Get<PlayerMovement2>().Enabled)
        {
            lblHighScore.text = Hub.Get<Highscore>().GetCurrentHighscore();
        }
    }
    
}
