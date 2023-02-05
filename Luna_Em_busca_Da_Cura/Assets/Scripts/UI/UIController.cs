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
    private List<UIItem> _uiItems;

    [SerializeField]
    private TextMeshProUGUI timer;

    [SerializeField]
    private DialogBox _dialogBox;

    private Dictionary<ItemType, UIItem> _items;
    private List<ItemInfo> _hudInfo;

    private bool _isPaused;

    public void Start()
    {
        Init();    
    }

    private void Init()
    {
        _hudInfo = new List<ItemInfo>();
        EnableItems(false);
        _dialogBox.gameObject.SetActive(false);
    }

    public void FiilUiItemList(List<SO_Item> collectable)
    {
        for(int i = 0; i < collectable.Count; i++)
        {
            var item = collectable[i];
            _uiItems[i].init(item);
        }

        InitDictionary();
    }

    private void InitDictionary()
    {
        _items = new Dictionary<ItemType, UIItem>();

        foreach (UIItem item in _uiItems)
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

    private void EnableItems(bool hide)
    {
        foreach(UIItem item in _uiItems)
        {
            item.EnableItem(hide);
        }
    }

    public void UpdateUIItem(ItemType type)
    {
        if(_items.ContainsKey(type))
        {
            var item = _items[type];
            item.UpdateQtd();
        }     
    }

    //Will get final results
    private List<ItemInfo> GetHudResults()
    {
        foreach(UIItem uiItem in _uiItems)
        {
            _hudInfo.Add(new ItemInfo()
            {
                type = uiItem.Type,
                qtd = uiItem.Qtd
            });
        }

        return _hudInfo;
    }
}
