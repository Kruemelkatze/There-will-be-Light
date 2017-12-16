﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

	public Transform[] superSegments;

	private float x = 0;
	private float y = 0;
	private float z = 0;

	public float superSegmentHeight = 47f;

	// Use this for initialization
	void Start () {

        Random.seed = GameManager.Seed;

 		for (int i = 0; i < 10; i++) {
			int segmentID = (int)Mathf.Floor(Random.value * (superSegments.Length));

			Instantiate(superSegments[segmentID], new Vector3(x, y, z), Quaternion.identity);

			y -= superSegmentHeight;

		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
