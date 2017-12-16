using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

	public GameObject[] superSegments;
	public GameObject startSegment;
	public GameObject endSegment;
	public int LevelLength;

	private float x = 0;
	private float y = 0;
	private float z = 0;

	public float segmentHeight = 12f;

    public List<GameObject> DisableOnGenerated;

	// Use this for initialization
	public void GenerateLevel () {
		Instantiate(startSegment, new Vector3(x, y, z), Quaternion.identity);

		for (int i = 0; i < LevelLength; i++) {
			int segmentID = (int)Mathf.Floor(Random.value * (superSegments.Length));

			y -= segmentHeight;

			// randomly rotate the segments
			if (Random.Range (1, 3) % 2 == 0) {
				Instantiate(superSegments[segmentID], new Vector3(x, y, z), Quaternion.Euler(0,180f,0));
			} else {
				Instantiate(superSegments[segmentID], new Vector3(x, y, z), Quaternion.identity);
			}
		}

		Instantiate(endSegment, new Vector3(x, y - segmentHeight, z), Quaternion.identity);

        foreach(var obj in DisableOnGenerated)
        {
            obj.SetActive(false);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
