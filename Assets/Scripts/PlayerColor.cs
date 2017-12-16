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

	// Use this for initialization
	void Start () {
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();

		playerLight = GetComponent<Light> ();

		switch((RndColor)Random.Range(0, 3)) {
			case RndColor.Red:
				renderer.color = new Color(1f, 0f, 0f, 1f);
				playerLight.color = new Color(1f, 0f, 0f, 1f);
				print("set player to color red");
				break;

			case RndColor.Green:
				renderer.color = new Color(0f, 1f, 0f, 1f);
				playerLight.color = new Color(0f, 1f, 0f, 1f);
				print("set player to color green");
				break;

			case RndColor.Blue:
				renderer.color = new Color(0.3f, 0.3f, 1f, 1f);
				playerLight.color = new Color(0.3f, 0.3f, 1f, 1f);
				break;

		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
