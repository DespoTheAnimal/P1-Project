using UnityEngine.Audio;
using System;
using UnityEngine;

// This script was stolen from Brackeys' tutorial: "Introduction to audio in Unity" DOI: https://youtu.be/6OT43pvUyfY 
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;  
    // Start is called before the first frame update
    void Awake()
    { 
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
        
    }

    public void Play (string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
