using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip AudioClip;
    [Range(0f, 1f)]
    public float Volume;
    [Range(.1f, 3f)]
    public float Picth;

    public bool Loop;

    [HideInInspector]
    public AudioSource source;
}
