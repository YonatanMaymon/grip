using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance;

    private void Awake()
    {


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    // start/stop the sound
    public void Play(string name , bool b)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("sound " + name + "was not found!");
            return;
        }
        if (b)
        {
            s.source.Play();
        }
        else
        {
            s.source.Stop();
        }
        
    }
    // controll the speed in wich the sound is playing
    public void Pitch (string name , float pitch)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("sound " + name + "was not found!");
            return;
        }
        s.source.pitch = pitch;
    }

    //check if sound is playing
    public bool IsPlaying(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        return s.source.isPlaying;
    }

}
