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
				renderer.color = new Color(0.937f, 0.231f, 0.212f, 1f);
				playerLight.color = new Color(0.937f, 0.231f, 0.212f, 1f);
				print("set player to color red");
				break;

			case RndColor.Green:
				renderer.color = new Color(0.059f, 0.608f, 0.059f, 1f);
				playerLight.color = new Color(0.059f, 0.608f, 0.059f, 1f);
				print("set player to color green");
				break;

			case RndColor.Blue:
				renderer.color = new Color(0f, 0.51f, 0.784f, 1f);
				playerLight.color = new Color(0f, 0.51f, 0.784f, 1f);
				break;

		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
