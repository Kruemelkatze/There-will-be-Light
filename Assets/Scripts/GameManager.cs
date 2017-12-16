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
    public static string StringSeed = "";
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
        Hub.Get<PlayerMovement2>().Enabled = false;
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

    public void StartGame(string seed)
    {
        //var tfObj = GameObject.FindGameObjectWithTag("seedinput");
        StringSeed = seed;
        Debug.Log($"Starting game with seed '{StringSeed}' = {Seed}");
        Random.InitState(Seed);
        
        generateLevel();
        Hub.Get<EventHub>().TriggerPlayercolorChangedEvent();
        Hub.Get<PlayerMovement2>().Enabled = true;
    }
}
