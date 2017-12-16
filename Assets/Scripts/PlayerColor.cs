using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour {

	private enum RndColor
	{
		Red,
		Green,
		Blue
	}

	private Light playerLight;

    void Start()
    {
        Hub.Get<EventHub>().PlayerColorChanged += ColorChanged;
        playerLight = GetComponent<Light>();
    }

    // Use this for initialization
    void ColorChanged () {
        switch (Hub.Get<GameManager>().CurrentColor)
        {
            case GameManager.PlayerColor.Red:
                playerLight.color = new Color(0.937f, 0.231f, 0.212f, 1f);
                break;
            case GameManager.PlayerColor.Blue:
                playerLight.color = new Color(0f, 0.51f, 0.784f, 1f);
                break;
            case GameManager.PlayerColor.Yellow:
                playerLight.color = new Color(0.608f, 0.608f, 0.059f, 1f);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
