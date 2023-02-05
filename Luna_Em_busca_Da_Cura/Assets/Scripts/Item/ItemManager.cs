using Core;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
            randomIndex = Random.Range(0, _itemCollectableList.Count - 1);

            var randomType = _itemCollectableList[randomIndex].Type;

            if (randomIndex != _previousItem)
            {
                if(CheckType(randomType))
                {
                    Debug.Log("item name:" + randomType.ToString());
                    _itemList.Add(randomType);
                }

                _previousItem = randomIndex;
            }
        }
        
        UIController.Instance.FiilUiItemList(_itemCollectableList);
    }

    private bool CheckType(ItemType type)
    {
        var count = _itemList.Where(x => x == type).Count();

        return count != 0 ? false : true;
    }

    public void NotifyItemManager(ItemType type)
    {
        UIController.Instance.UpdateUIItem(type);
    }
}
