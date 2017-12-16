using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum PlayerColor
    {
        Red,
        Yellow,
        Blue
    }

    public GameObject checkpoint;
    public static string StringSeed = "alsdkjhjakshdkjhas";
    public PlayerColor CurrentColor = PlayerColor.Yellow;

    public static int Seed
    {
        get
        {
            return StringSeed.GetHashCode();
        }
    }

    // Use this for initialization
    void Start()
    {
        generateLevel();
        Hub.Get<EventHub>().TriggerPlayercolorChangedEvent();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void generateLevel()
    {
        generateCheckpoint();
    }

    void generateCheckpoint()
    {
        Instantiate(checkpoint, new Vector3(0.25f, 4, 0), Quaternion.identity);
    }

    public void switchColor()
    {
        CurrentColor = (PlayerColor)Random.Range(0, 3);
        Hub.Get<EventHub>().TriggerPlayercolorChangedEvent();
    }
}
