using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject ToFollow;
    private Rigidbody2D _targetRigid;
    public float yOffset = -2;

	// Use this for initialization
	void Start () {
        _targetRigid = ToFollow.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        var position = new Vector3(transform.position.x, ToFollow.transform.position.y + yOffset, transform.position.z);
        transform.position = position;
    }
}
