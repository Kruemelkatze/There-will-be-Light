using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour {


    private Rigidbody2D rigid;
    public float Speed = 5;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
        rigid.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Speed;
    }
}
