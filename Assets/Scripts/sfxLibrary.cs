using System;
using System.Collections.Generic;
using UnityEngine;

public class sfxLibrary : MonoBehaviour
{

    [SerializeField] private SfxGroup[] SfxGroups;
    private Dictionary<string, List<AudioClip>> soundDictionary;


    private void Awake()
    {

        InitializeDictionary();

    }

    private void InitializeDictionary()
    {

        soundDictionary = new Dictionary<string, List<AudioClip>>();

        foreach (SfxGroup SfxGroup in SfxGroups)
        {
            soundDictionary[SfxGroup.name] = SfxGroup.audioClips;
        }

    }

    public AudioClip GetRandomClip(string name)
    {
        if (soundDictionary.ContainsKey(name))
        {
            List<AudioClip> audioClips = soundDictionary[name];
            if(audioClips.Count > 0)
            {
                return audioClips[UnityEngine.Random.Range(0, audioClips.Count)];
            }
        }
        return null;
    }

}


[System.Serializable]
public struct SfxGroup
{

    public string name;
    public List<AudioClip> audioClips;

}
