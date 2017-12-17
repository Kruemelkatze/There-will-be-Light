using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public enum PlayerColor
    {
        Red,
        Yellow,
        Blue
    }

    public GameObject checkpoint;
    public static string StringSeed = "";
    public PlayerColor CurrentColor = PlayerColor.Yellow;
    private GameObject _player;

    public Vector2 CheckpointSpawnOffset = new Vector2(0, 0);

    // Awake is always called before any Start functions
    void Awake()
    {
        // Check if instance already exists
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    public PlayerColor[] ColorDistribution = {
        PlayerColor.Yellow, PlayerColor.Yellow,PlayerColor.Yellow,PlayerColor.Yellow,PlayerColor.Yellow, // 50%
        PlayerColor.Red, PlayerColor.Red, PlayerColor.Red, // 30%
        PlayerColor.Blue, PlayerColor.Blue, // 20%
    };

    public static int Seed
    {
        get
        {
            return StringSeed.GetHashCode();
        }
    }

    public bool GameStarted = false;
    public bool GamePaused = true;

    // Use this for initialization
    void Start()
    {
        Hub.Get<PlayerMovement2>().Enabled = false;
        _player = GameObject.FindGameObjectWithTag("Player");
        _player.SetActive(false);
        Debug.Log(_player);
    }


    void SetupLevel()
    {
        Hub.Get<LevelGeneration>().GenerateLevel();
        generateCheckpoint();
    }

    void generateCheckpoint()
    {
        Instantiate(checkpoint, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void switchColor(PlayerColor? color = null)
    {
        if (color != null)
        {
            CurrentColor = color.Value;
        }
        else
        {
            int i = Random.Range(0, ColorDistribution.Length);
            CurrentColor = ColorDistribution[i];
        }

        Hub.Get<EventHub>().TriggerPlayercolorChangedEvent();
    }

    public void SetCheckpoint(Vector3 collisionPos)
    {
        Vector3 vec3Checkpoint = GameObject.FindGameObjectWithTag("checkpoint").transform.position;
        vec3Checkpoint = new Vector3(vec3Checkpoint.x, collisionPos.y, vec3Checkpoint.z);
        GameObject.FindGameObjectWithTag("checkpoint").transform.position = vec3Checkpoint + new Vector3(CheckpointSpawnOffset.x, CheckpointSpawnOffset.y);
    }

    public void StartGame(string seed)
    {
        StringSeed = seed?.ToLowerInvariant() ?? "42";
        Debug.Log($"Starting game with seed '{StringSeed}' = {Seed}");
        Random.InitState(Seed);

        SetupLevel();
        GameStarted = true;
        _player.SetActive(true);
        switchColor(CurrentColor);
        Hub.Get<PlayerMovement2>().Enabled = true;
        Hub.Get<Highscore>().StartLevel(StringSeed);
    }

    public void PauseGame()
    {
        Hub.Get<PlayerMovement2>().Enabled = false;
        GamePaused = true;
    }

    public void RemainGame()
    {
        Hub.Get<PlayerMovement2>().Enabled = true;
        GamePaused = false;
    }

    public void EndGame()
    {
        Hub.Get<PlayerMovement2>().Enabled = false;
        Hub.Get<UIManager>().ShowEndScreen(Hub.Get<Highscore>().EndLevel());
    }
}
