using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollison : MonoBehaviour
{

    public GameObject explosion;
    public GameObject implosion;

    public LayerMask ObstacleLayerMask;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Start");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Contains(ObstacleLayerMask, other.gameObject.layer))
        {
            Debug.Log("BOOM");
            if (explosion != null)
            {
                Instantiate(explosion, this.transform.position, Quaternion.identity);
            }
            this.transform.position = GameObject.FindGameObjectWithTag("checkpoint").transform.position;
        }
    }

    public static bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
