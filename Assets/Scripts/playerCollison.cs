using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollison : MonoBehaviour
{
    public GameObject explosion;
    public GameObject implosion;
    public GameObject sunAnimation;

    private Color red = new Color(1, 0, 0, 1);
    private Color blue = new Color(0, 0, 1, 1);
    private Color green = new Color(0, 1, 0, 1);
    private Color standard = new Color(1, 1, 1, 1);

    public LayerMask ObstacleLayerMask;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            changeColor(red);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            changeColor(blue);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            changeColor(green);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            changeColor(standard);
        }
    }

    void changeColor(Color clr)
    {
        sunAnimation.GetComponent<ParticleSystem>().startColor = clr;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Contains(ObstacleLayerMask, other.gameObject.layer))
        {
            Debug.Log("BOOM");
            if (explosion != null)
            {
                // @TODO: StopMovement of the player
                Instantiate(explosion, this.transform.position, Quaternion.identity);
                sunAnimation.SetActive(false);
                StartCoroutine(waitNewTurn());
            }
            this.transform.position = GameObject.FindGameObjectWithTag("checkpoint").transform.position;
        }
    }

    public static bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }

    IEnumerator waitNewTurn()
    {
        print(Time.time);
        yield return new WaitForSeconds(4);
        this.transform.position = GameObject.FindGameObjectWithTag("checkpoint").transform.position;
        yield return new WaitForSeconds(1);
        sunAnimation.SetActive(true);
        print(Time.time);
    }
}
