using Core;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public delegate List<ItemInfo> OnItemToShow();
    public event OnItemToShow onItemToShow;

    private List<ItemInfo> _gameItems;

    public void Start()
    {
        InitializeItems();
    }

    public void Update()
    {
       
    }

    private void InitializeItems()
    {
        List<ItemInfo> _gameItems = new List<ItemInfo>();
        ItemManager.Instance.RandomizeItems();
    }

    //code to get when is the healer parte to tell luna the ingredients of this run
    private void GetItemInformationForHealer()
    {
        _gameItems = onItemToShow.Invoke();
    }
}
