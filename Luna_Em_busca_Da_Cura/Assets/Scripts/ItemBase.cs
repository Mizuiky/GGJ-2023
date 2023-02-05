using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Carrot,
    Beet,
    Manioc
}

public class ItemBase : MonoBehaviour
{
    protected string _name;
    protected ItemType _type;
    protected int _pontuation;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

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

    public virtual void OnCollect()
    {

    }
}
