using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour {
    public int maxPoints = 9999;

    private float highscore;

    private string currentSeed = null;

    private static Dictionary<string, int> highscores = new Dictionary<string, int>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Hub.Get<GameManager>().GameStarted)
        {
            highscore -= (Time.deltaTime * 100f);
        }
	}

    private void SetSeed(string seed)
    {
        currentSeed = seed;
        
        if (!highscores.ContainsKey(seed))
        {
            highscores.Add(seed, 0);
        }
    }

    private int GetSeedHighscore(string seed)
    {
        if (highscores.ContainsKey(seed))
        {
            return highscores[seed];
        }

        return maxPoints;
    }

    private void SetSeedHighscore(string seed, float newHighscore)
    {
        if (!highscores.ContainsKey(seed))
        {
            highscores.Add(seed, 0);
        }

        highscores[seed] = (int)newHighscore;
    }

    public void StartLevel(string seed)
    {
        SetSeed(seed);

        highscore = maxPoints;
    }

    public void EndLevel()
    {
        SetSeedHighscore(currentSeed, highscore);
    }

    public string GetCurrentHighscore()
    {
        return ((int)highscore).ToString();
    }

    public int GetHighscore(string seed)
    {
        return GetSeedHighscore(seed);
    }
}
