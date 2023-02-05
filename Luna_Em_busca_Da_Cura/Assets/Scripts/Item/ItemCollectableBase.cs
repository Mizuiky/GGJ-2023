using UnityEngine;

public enum ItemType
{
    Carrot,
    Beet,
    Orange
}

public class ItemCollectableBase : MonoBehaviour, IItemCollectable
{
    public string _name;
    protected ItemType _type;
    protected int _pontuation;

    private AudioClip _audio;
    private ParticleSystem _particle;

    [SerializeField]
    private SO_Item _itemInfo;

    public ItemType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public int Pontuation
    {
        get { return _pontuation; }
        set { _pontuation = value; }
    }

    public void Start()
    {
        Init();
    }

    public void OnValidate()
    {
        Init();
    }

    public void Init()
    {
        _name = _itemInfo.Name;
        _type = _itemInfo.Type;
        _pontuation = _itemInfo.Pontuation;
        _particle = _itemInfo._particle;
        _audio = _itemInfo._OnCollectAudio;
    }

    public virtual void OnCollect()
    {
        //audio
        //particula
    }
}
