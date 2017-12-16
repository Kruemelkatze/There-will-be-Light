using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollison : MonoBehaviour
{

    public GameObject explosion;
    public GameObject implosion;

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
        Debug.Log("Enter " + other.tag);
        if (other.gameObject.tag.Equals("red"))
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            this.transform.position = GameObject.FindGameObjectWithTag("checkpoint").transform.position;
        }
    }
}
