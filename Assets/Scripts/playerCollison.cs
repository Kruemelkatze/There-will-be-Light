using Prime31.TransitionKit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollison : MonoBehaviour
{
    public GameObject RedWave;
    public GameObject YellowWave;
    public GameObject BlueWave;

    public GameObject implosion;
    public GameObject sunAnimation;

    private Color red = new Color(1, 0.5f, 0, 1);
    private Color blue = new Color(0, 0, 1, 0.7f);
    private Color yellow = new Color(1, 1, 1, 1);

    public GameObject RedLight;
    public GameObject BlueLight;
    public GameObject YellowLight;

    public LayerMask ObstacleLayerMask;

    public float ImmunityTime = 1.5f;
    public bool CollisionDisabled = false;

    public float WaitBeforePixel = 0.7f;
    public float WaitBetweenPixelateAndTP = 0.7f;

    // Use this for initialization
    void Start()
    {
        Hub.Get<EventHub>().PlayerColorChanged += ColorChanged;
    }

    private void ColorChanged()
    {
        switch (Hub.Get<GameManager>().CurrentColor)
        {
            case GameManager.PlayerColor.Red:
                changeColor(red);
                break;
            case GameManager.PlayerColor.Blue:
                changeColor(blue);
                break;
            case GameManager.PlayerColor.Yellow:
                changeColor(yellow);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void changeColor(Color clr)
    {
        sunAnimation.GetComponent<ParticleSystem>().startColor = clr;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (CollisionDisabled)
            return;

        if (other.gameObject.tag.Equals("endOfMap"))
        {
            Hub.Get<GameManager>().EndGame();
            CreateSplash();
            ThereWillBeLight();
        }
        else
        {
            if (Contains(ObstacleLayerMask, other.gameObject.layer))
            {
                Debug.Log("BOOM");
                CreateSplash();
                ThereWillBeLight();

                DeactivateSun();
                StartCoroutine(waitNewTurn());
                //this.transform.position = GameObject.FindGameObjectWithTag("checkpoint").transform.position;
            }
        }
    }

    private void DeactivateSun()
    {
        sunAnimation.SetActive(false);
        Hub.Get<PlayerMovement2>().Enabled = false;
        //StartCoroutine(waitNewTurn());
    }

    private void CreateSplash()
    {
        GameObject explosion = null;
        switch (Hub.Get<GameManager>().CurrentColor)
        {
            case GameManager.PlayerColor.Red:
                explosion = RedWave;
                break;
            case GameManager.PlayerColor.Blue:
                explosion = BlueWave;
                break;
            case GameManager.PlayerColor.Yellow:
                explosion = YellowWave;
                break;
        }

        if (explosion != null)
        {
            var position = new Vector3(transform.position.x, transform.position.y, -2);
            var created = Instantiate(explosion, position, Quaternion.identity);
        }
    }

    private void ThereWillBeLight()
    {
        GameObject light = null;
        switch (Hub.Get<GameManager>().CurrentColor)
        {
            case GameManager.PlayerColor.Red:
                light = RedLight;
                break;
            case GameManager.PlayerColor.Blue:
                light = BlueLight;
                Hub.Get<GameManager>().SetCheckpoint(transform.position);
                break;
            case GameManager.PlayerColor.Yellow:
                light = YellowLight;
                break;
        }
        var targetPos = new Vector3(transform.position.x, transform.position.y, -1);
        Instantiate(light, targetPos, Quaternion.identity);
    }

    public static bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }

    IEnumerator waitNewTurn()
    {
        CollisionDisabled = true;
        yield return new WaitForSeconds(WaitBeforePixel);

        var pixelater = new PixelateTransition()
        {
            nextScene = -1,
            duration = 0.7f
        };
        TransitionKit.instance.transitionWithDelegate(pixelater);

        Hub.Get<GameManager>().switchColor();
        yield return new WaitForSeconds(WaitBetweenPixelateAndTP);
        var targetPos = GameObject.FindGameObjectWithTag("checkpoint").transform.position;
        this.transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);

        StartCoroutine(EnableCollisionAfterTimeout());

        sunAnimation.SetActive(true);
        Hub.Get<PlayerMovement2>().Enabled = true;
    }

    IEnumerator EnableCollisionAfterTimeout()
    {
        yield return new WaitForSeconds(ImmunityTime);
        CollisionDisabled = false;
    }
}
