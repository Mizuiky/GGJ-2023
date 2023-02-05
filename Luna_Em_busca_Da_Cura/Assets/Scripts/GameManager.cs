using Core;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private SceneController _sceneController;

    public delegate List<ItemInfo> OnItemToShow();
    public event OnItemToShow onItemToShow;

    private List<ItemInfo> _gameItems;

    private bool _isGameRunning = false;

    public void Start()
    {
        InitializeItems();
        InitializeMainMenu();
    }

    public void Update()
    {
       if(_isGameRunning)
        {

        }
    }

    #region Manage Items

    private void InitializeItems()
    {
        List<ItemInfo> _gameItems = new List<ItemInfo>();

        ItemManager.Instance.RandomizeItems();

        _isGameRunning = true;
    }

    private void GetItemInformationForHealer()
    {
        _gameItems = onItemToShow.Invoke();
    }

    private void GetHUDFinalResults()
    {

    }

    #endregion

    #region Manage Scenes

    private void InitializeMainMenu()
    {
        _sceneController.LoadAdditiveScene(sceneType.SCN_Vilage);
    }

    #endregion

    //code to get when is the healer parte to tell luna the ingredients of this run
    
}
