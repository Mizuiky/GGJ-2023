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

    private Dictionary<ItemType, UIItem> _items;

    private bool _isPaused;

    public void FiilUiItemList(List<SO_Item> collectable)
    {
        for(int i = 0; i < collectable.Count; i++)
        {
            var item = collectable[i];
            UiItems[i].init(item);
        }

        InitDictionary();
    }

    private void InitDictionary()
    {
        _items = new Dictionary<ItemType, UIItem>();

        foreach (UIItem item in UiItems)
        {
            _items.Add(item.Type, item);
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if(_isPaused)
        {
            _isPaused = false;
            //open pause game
            Time.timeScale = 0f;
        }
    }

    public void UpdateUIItem(ItemType type)
    {
        var item = _items[type];
        item.UpdateQtd();
    }
}
