using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIItem : MonoBehaviour
{
    [SerializeField]
    private Image _itemImage;

    [SerializeField]
    private TextMeshProUGUI _qtd;

    private ItemType _type;

    private int _increment;
    private int _currentValue;
    
    public ItemType Type
    {
        get => _type;
    }

    public int Qtd
    {
        get => Int32.Parse(_qtd.text);
    }

    public void init(SO_Item itemInfo)
    {
        _type = itemInfo.Type;
        _increment = 1;
        _currentValue = 0;
        _qtd.text = _currentValue.ToString();
        _itemImage.sprite = itemInfo._itemImage;
    }

    public void UpdateQtd()
    {
        _currentValue += _increment;
        _qtd.text = _currentValue.ToString();
    }
}
