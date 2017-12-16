using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollison : MonoBehaviour
{
    public GameObject explosion;
    public GameObject implosion;
    public GameObject sunAnimation;

    private Color red = new Color(1, 0.5f, 0, 1);
    private Color blue = new Color(0, 0, 1, 0.7f);
    private Color green = new Color(0, 1, 0, 0.7f);
    private Color standard = new Color(1, 1, 1, 1);

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
            //DeactivateSun();
            CreateSplash();
            ThereWillBeLight();
            this.transform.position = GameObject.FindGameObjectWithTag("checkpoint").transform.position;
        }
    }

    private void DeactivateSun()
    {
        sunAnimation.SetActive(false);
        StartCoroutine(waitNewTurn());
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

    IEnumerator waitNewTurn()
    {
        print(Time.time);
        yield return new WaitForSeconds(1);
        this.transform.position = GameObject.FindGameObjectWithTag("checkpoint").transform.position;
        yield return new WaitForSeconds(1);
        sunAnimation.SetActive(true);
        print(Time.time);
    }
}
