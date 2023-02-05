using Core;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private ItemManager _itemManager;

    public delegate List<ItemInfo> OnItemToShow();
    public event OnItemToShow onItemToShow;

    private List<ItemInfo> _gameItems;

    public void Start()
    {
        InitializeItems();
    }

    public void Update()
    {
       if(Input.GetKeyDown(KeyCode.G))
       {
            GetItemInformationForHealer();
       }
    }

    private void InitializeItems()
    {
        List<ItemInfo> _gameItems = new List<ItemInfo>();
        _itemManager.RandomizeItems();
    }

    private void GetItemInformationForHealer()
    {
        _gameItems = onItemToShow.Invoke();
        Debug.Log(_gameItems);
    }
}
