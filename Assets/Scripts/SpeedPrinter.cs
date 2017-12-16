using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPrinter : MonoBehaviour {

    public Text text;

    private Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = $"{rigid.velocity.x} {rigid.velocity.y}";
	}
}
