using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	private Rigidbody2D rigidbody2D;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public KeyCode moveLeft = KeyCode.LeftArrow;
	public KeyCode moveRight = KeyCode.RightArrow;
	public KeyCode moveDown = KeyCode.DownArrow;
	public KeyCode moveUp = KeyCode.UpArrow;

	private float targetTime = 2.0f;  // max keypress time
	private float currentTime = 0.0f; // already pressed time

	private int hSpeed = 0;
	public int hSpeedMax = 6;

	public float vSpeed = 2;

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
			// change horizontal direction
			hSpeed = -hSpeedMax;
		} else if (Input.GetKey(moveRight)) {
			// change horizontal direction
			hSpeed = hSpeedMax;
		} else if(Input.GetKey(moveDown)) {

			currentTime += Time.deltaTime;

			// increase the key-pressed timer
			if (currentTime < targetTime) {
				speedUp ();
			}

			//1-(1/(A1*100))

//			vSpeed = -8+(1 + (1 / (Mathf.Ceil(currentTime))));

//			rigidbody2D.velocity = new Vector2(hSpeed, vSpeed*-1f);


		} else if(Input.GetKey(moveUp)) {
//			rigidbody2D.velocity = new Vector2(0, vSpeed/2);




			rigidbody2D.velocity = new Vector2(0, 0);
			currentTime = 0;
		} else {
			// no button is pressed
			hSpeed = 0;
			vSpeed = vSpeedDefault;
		}


		print (hSpeed + " - " + vSpeed);

		rigidbody2D.velocity = new Vector2(hSpeed, vSpeed*-1);


	}

	private void speedUp() {
		this.vSpeed += (1f / 3f);
		print (vSpeed);
	}

	private void slowDown() {
		vSpeed -= (1 / 3);
	}

}
