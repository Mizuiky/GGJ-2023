using Core;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField]
    private List<SO_Item> _itemCollectableList;

    private List<SO_Item> _itemList;
    private List<ItemInfo> _itemInfoList;

    private int _previousItem;
    private int randomIndex;

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        _itemList = new List<SO_Item>();
        _itemInfoList = new List<ItemInfo>();

        GameManager.Instance.onItemToShow += SendItemsToShow;

        _previousItem = -1;
        randomIndex = -1;
    }

    public void RandomizeItems()
    {
        while (_itemList.Count < _itemCollectableList.Count)
        {
            randomIndex = Random.Range(0, _itemCollectableList.Count);

            var randomItem = _itemCollectableList[randomIndex];

            if (randomIndex != _previousItem)
            {
                if(CheckType(randomItem.Type))
                {
                    //Debug.Log("item name:" + randomItem.ToString());
                    _itemList.Add(randomItem);

                    if (_itemList.Count == 3)
                    {
                        UIController.Instance.FiilUiItemList(_itemList);
                        return;
                    }                  
                }
                _previousItem = randomIndex;
            }
         }    
    }

    private bool CheckType(ItemType type)
    {
        var count = _itemList.Where(x => x.Type == type).Count();

        return count != 0 ? false : true;
    }

    public void NotifyUiController(ItemType type)
    {
        UIController.Instance.UpdateUIItem(type);
    }

    private void SetCurrentItemInfo()
    {
        foreach(SO_Item item in _itemList)
        {
            _itemInfoList.Add(new ItemInfo()
            {
                type = item.Type,
                qtd = item.Pontuation
            });
        }
    }
    public List<ItemInfo> SendItemsToShow()
    {
        SetCurrentItemInfo();

        return _itemInfoList;
    }
}

public struct ItemInfo
{
    public ItemType type;
    public int qtd;
}
