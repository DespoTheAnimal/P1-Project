using UnityEngine.Audio;
using UnityEngine;

// This script was stolen from Brackeys' tutorial: "Introduction to audio in Unity" DOI: https://youtu.be/6OT43pvUyfY 
[System.Serializable]
public class Sound
{
    public string name; 
    public AudioClip clip;

    [Range(0.0f,1.0f)]
    public float volume;
    [Range(0.1f,3f)]
    public float pitch;

    public bool loop;

    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}
