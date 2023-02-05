using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class SO_Item : ScriptableObject
{
    public string Name;

    public Sprite _itemImage;

    public ItemType Type;

    public int Pontuation;

    public ParticleSystem _particle;

    public AudioClip _OnCollectAudio;
}
