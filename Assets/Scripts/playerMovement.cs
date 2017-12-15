using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	private Rigidbody2D rigidbody2D;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode moveDown;
	public KeyCode moveUp;

	private float targetTime = 2.0f;  // max keypress time
	private float currentTime = 0.0f; // already pressed time

	private float speed = 6;

	private float vSpeed = 2;

	private float vSpeedDefault = 2;
	private float vSpeedMax = 8;

	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rigidbody2D = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey(moveLeft)) {
//			rigidbody2D.velocity = new Vector2(speed *-1, vSpeed);
		} else if (Input.GetKey(moveRight)) {
//			rigidbody2D.velocity = new Vector2(speed, vSpeed);
		} else if(Input.GetKey(moveDown)) {

			currentTime += Time.deltaTime;

			// increase the key-pressed timer
			if (currentTime < targetTime) {
				speedUp ();
			}

			//1-(1/(A1*100))

//			vSpeed = -8+(1 + (1 / (Mathf.Ceil(currentTime))));

			rigidbody2D.velocity = new Vector2(0, vSpeed*-1f);


		} else if(Input.GetKey(moveUp)) {
//			rigidbody2D.velocity = new Vector2(0, vSpeed/2);




			rigidbody2D.velocity = new Vector2(0, 0);
			currentTime = 0;
		} else {
//			rigidbody2D.velocity = new Vector2(0, vSpeed);
		}

//		rigidbody2D.velocity = new Vector2(0, 0);


	}

	private void speedUp() {
		this.vSpeed += (1f / 3f);
		print (vSpeed);
	}

	private void slowDown() {
		vSpeed -= (1 / 3);
	}

}
