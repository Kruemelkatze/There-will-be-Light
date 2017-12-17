using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ParallelMusicManager : MonoBehaviour
{
    private const float LowerVolumeLimit = 0.05f;
    public float FadeSpeed = 0.3f;
    public float MaxPitchDeviation = 0.2f;

    public AudioClip[] AudioClips;

    //public AudioClip bass01;
    //public AudioClip bass02;
    //public AudioClip drums01;
    //public AudioClip lead01;
    //public AudioClip lead02;
    //public AudioClip lead03;

    public AudioSource[] AudioSources;

    public int[] YellowTracks = { 0, 2, 3 };
    public int[] RedTracks = { 0, 2, 4 };
    public int[] BlueTracks = { 1, 2, 5 };

    public int[] DefaultTracks = new int[0];

    private int[] _currentTracks;

    public float MaxMusicVolume = 1;

    // Use this for initialization
    void Start()
    {
        AudioSources = new AudioSource[AudioClips.Length];
        for (int i = 0; i < AudioSources.Length; i++)
        {
            AudioSources[i] = gameObject.AddComponent<AudioSource>();
            AudioSources[i].loop = true;
            AudioSources[i].clip = AudioClips[i];
            AudioSources[i].volume = 0;
            AudioSources[i].Stop();
            AudioSources[i].Play();
        }

        if (DefaultTracks.Length == 0)
        {
            DefaultTracks = (int[])YellowTracks.Clone();
        }

        SetTracks(DefaultTracks);
        Hub.Get<EventHub>().PlayerColorChanged += ColorChanged;
    }

    public void ChangePitch(float increaseRatioInPercent)
    {
        float absPitch = 1f + MaxPitchDeviation * increaseRatioInPercent;
        foreach (var source in AudioSources)
        {
            source.pitch = absPitch;
        }
    }

    private void ColorChanged()
    {
        switch (Hub.Get<GameManager>().CurrentColor)
        {
            case GameManager.PlayerColor.Red:
                SetTracks(RedTracks);
                break;
            case GameManager.PlayerColor.Blue:
                SetTracks(BlueTracks);
                break;
            case GameManager.PlayerColor.Yellow:
                SetTracks(YellowTracks);
                break;
        }
    }

    private void SetTracks(int[] tracks)
    {
        _currentTracks = tracks;
        Debug.Log($"Now playing: {tracks[0]} {tracks[1]} {tracks[2]}");
        for (int i = 0; i < AudioSources.Length; i++)
        {
            var source = AudioSources[i];
            bool playedBefore = source.volume > LowerVolumeLimit;
            bool playNow = ArrayUtility.Contains(tracks, i);

            if (!playedBefore && playNow)
            {
                source.FadeTo(MaxMusicVolume, FadeSpeed, null);
            }
            else if (playedBefore && !playNow)
            {
                source.FadeTo(0, FadeSpeed, null);
            }
        }
    }
}
