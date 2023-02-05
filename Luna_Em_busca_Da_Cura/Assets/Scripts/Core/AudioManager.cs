using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager inst = null;

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.AudioSource = gameObject.AddComponent<AudioSource>();
            s.AudioSource.clip = s.AudioClip;
            s.AudioSource.volume = s.Volume;
            s.AudioSource.pitch = s.Picth;
            s.AudioSource.loop = s.Loop;
        }
    }

    public void PlayAudio(string name)
    {
        var s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
            Debug.LogWarning($"Not find sound with name {name}");
        else
        {
            s.AudioSource.Play();
            print("ASDASDASD");
        }
    }
}
