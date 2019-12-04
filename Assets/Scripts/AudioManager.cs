using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    float Volume;
    public Slider vol;

    //Setting up each sounds settings
    void Awake()
    {
        foreach (Sound s in sounds)
        {

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            Volume = PlayerPrefs.GetFloat("Volume", 1);
            s.source.volume = Volume;
        }
    }

    //Play a specific audio clip on command
    public void Play(string name)
    {
        Sound s= Array.Find(sounds, sounds => sounds.name == name);
        
        if (s == null){
        Debug.LogWarning("Sound: " + name + " not found!");
         return;
        }
        s.source.Play();
    }
        
    //Changing the volume in game, passing using PlayerPrefs to the game
    public void SetGameVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }
}
