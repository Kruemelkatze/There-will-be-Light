using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

	public string seed;
	public Transform[] superSegments;

	private float x = 14.44576f;
	private float y = 0;
	private float z = -0.8025516f;

	private float superSegmentHeight = 47f;

	// Use this for initialization
	void Start () {
		

		Random.seed = seed.GetHashCode();

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
