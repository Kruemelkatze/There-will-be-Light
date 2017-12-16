using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharLight : MonoBehaviour
{

    public GameObject Red;
    public GameObject Yellow;
    public GameObject Blue;

    // Use this for initialization
    void Start()
    {
        Hub.Get<EventHub>().PlayerColorChanged += ColorChanged;
    }

    private void ColorChanged()
    {
        Red.SetActive(false);
        Blue.SetActive(false);
        Yellow.SetActive(false);

        switch (Hub.Get<GameManager>().CurrentColor)
        {
            case GameManager.PlayerColor.Red:
                Red.SetActive(true);
                break;
            case GameManager.PlayerColor.Blue:
                Blue.SetActive(true);
                break;
            case GameManager.PlayerColor.Yellow:
                Yellow.SetActive(true);
                break;
        }
    }
}
