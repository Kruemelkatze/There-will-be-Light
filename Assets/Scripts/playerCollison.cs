using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollison : MonoBehaviour
{

    public GameObject explosion;
    public GameObject implosion;

    public GameObject RedLight;
    public GameObject BlueLight;
    public GameObject YellowLight;

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
            CreateSplash();
            ThereWillBeLight();

            this.transform.position = GameObject.FindGameObjectWithTag("checkpoint").transform.position;
        }
    }

    private void CreateSplash()
    {
        if (explosion != null)
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
        }
    }

    private void ThereWillBeLight()
    {
        //TODO: Different colors
        Instantiate(RedLight, this.transform.position, Quaternion.identity);
    }

    public static bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
