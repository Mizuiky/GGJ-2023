using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class UIController : Singleton<UIController>
{
    [SerializeField]
    private List<UIItem> UiItems;

    public TextMeshProUGUI timer;

    public Button pause;

    private Dictionary<ItemType, UIItem> _items;

    private bool _isPaused;

    private void InitDictionary()
    {
        _items = new Dictionary<ItemType, UIItem>();

        foreach(UIItem item in UiItems)
        {
            _items.Add(item.Type, item);
        }
    }

    public void PauseGame()
    {
        if(_isPaused)
        {
            _isPaused = false;
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void UpdateUIItem(ItemType type)
    {
        var item = _items[type];
        item.UpdateQtd();
    }
}
