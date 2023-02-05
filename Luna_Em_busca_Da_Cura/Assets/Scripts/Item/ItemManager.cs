using Core;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField]
    private List<SO_Item> _itemCollectableList;

    private List<ItemType> _itemList;

    private int _previousItem;
    private int randomIndex;

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        _itemList = new List<ItemType>();

        _previousItem = -1;
        randomIndex = -1;
    }

    public void RandomizeItems()
    {
        while (_itemList.Count < _itemCollectableList.Count)
        {
            if(randomIndex != _previousItem)
            {
                _itemList.Add(_itemCollectableList[randomIndex].Type);              
            }
            else
            {
                randomIndex = Random.Range(0, _itemCollectableList.Count - 1);
            }

            _previousItem = randomIndex;
        }
        
        UIController.Instance.FiilUiItemList(_itemCollectableList);
    }

    public void NotifyItemManager(ItemType type)
    {
        UIController.Instance.UpdateUIItem(type);
    }
}
