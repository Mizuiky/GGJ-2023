using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField]
    private Image item;

    [SerializeField]
    private TextMeshProUGUI _qtd;

    private ItemType _type;

    private int _increment;
    private int _currentValue;
    
    public ItemType Type
    {
        get => _type;
    }

    public void init(ItemType type, int increment)
    {
        _type = type;
        _increment = increment;
        _currentValue = 0;
    }

    public void UpdateQtd()
    {
        _currentValue += _increment;
        _qtd.text = _currentValue.ToString();
    }
}
