using System;
using UnityEngine;
using Core;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;

    private void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.AudioClip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Picth;
            s.source.loop = s.Loop;
        }
    }

    public void PlayAudio(string name)
    {
        var s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
            Debug.LogWarning($"Not find sound with name {name}");
        else if (!s.source.isPlaying)
            s.source.Play();
    }

    public void StopAudio(string name)
    {
        var s = Array.Find(sounds, sound => sound.Name == name);
        if (s != null && s.source.isPlaying)
            s.source.Stop();
    }
}
