using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class ItemManager : Singleton<ItemManager>
{
    private List<SO_Item> _itemCollectable;

    private List<ItemType> _listSet;

    private void RandomizeItens()
    {
        //var random
        UIController.Instance.FiilUiItemList(_itemCollectable);
    }

    public void NotifyItemManager(ItemType type)
    {
        UIController.Instance.UpdateUIItem(type);
    }
}
