using Prime31.TransitionKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public InputField SeedTextField;

    public GameObject HUD;
    public GameObject SeedScreen;

    public List<string> DefaultSeeds;

    public float WaitAfterEmptySeed = 1f;

    public Text hudSeed;
    public Text hudHighscore;

    // Use this for initialization
    void Start()
    {
        SeedTextField.Select();
    }

    void Update()
    {

    }

    public void OnSeedEditEnd()
    {
        var text = SeedTextField.text;
        if (string.IsNullOrWhiteSpace(text))
        {
            Debug.Log("No seed entered");
            int i = Random.Range(0, DefaultSeeds.Count);
            text = DefaultSeeds[i];
            SeedTextField.text = text;

            StartCoroutine(CallStart(text));
        }
        else
        {
            HUD.SetActive(true);
            SeedScreen.SetActive(false);
            Hub.Get<GameManager>().StartGame(text);
        }

    }

    IEnumerator CallStart(string text)
    {
        yield return new WaitForSeconds(WaitAfterEmptySeed);
        var pixelater = new PixelateTransition()
        {
            nextScene = -1,
            duration = 0.7f
        };
        TransitionKit.instance.transitionWithDelegate(pixelater);

        yield return new WaitForSeconds(0.7f);
        HUD.SetActive(true);
        SeedScreen.SetActive(false);
        Hub.Get<GameManager>().StartGame(text);
    }
}
