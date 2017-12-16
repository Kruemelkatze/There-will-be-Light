using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject SeedTextField;
    private InputField _input;

    public List<string> DefaultSeeds;

    public float WaitAfterEmptySeed = 0.5f;

    // Use this for initialization
    void Start()
    {
        if (SeedTextField != null)
            _input = SeedTextField.GetComponent<InputField>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSeedEditEnd()
    {
        var text = _input.text;
        if (string.IsNullOrWhiteSpace(text))
        { 
            Debug.Log("No seed entered");
            int i = Random.Range(0, DefaultSeeds.Count);
            text = DefaultSeeds[i];
            _input.text = text;

            StartCoroutine(CallStart(text));
        } else
        {
            Hub.Get<GameManager>().StartGame(text);
        }

    }

    IEnumerator CallStart(string text)
    {
        yield return new WaitForSeconds(WaitAfterEmptySeed);
        Hub.Get<GameManager>().StartGame(text);
    }
}
