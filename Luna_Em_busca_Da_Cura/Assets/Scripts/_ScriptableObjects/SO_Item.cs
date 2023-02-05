using UnityEngine;

[CreateAssetMenu]
public class SO_Item : ScriptableObject
{
    public string Name;

    public ItemType Type;

    public int Pontuation;

    public ParticleSystem _particle;

    public AudioClip _OnCollectAudio;
}
