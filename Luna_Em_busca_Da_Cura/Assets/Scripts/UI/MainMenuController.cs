using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject _credits;

    public void Start()
    {
        AudioManager.Instance.PlayAudio("MainMenuSound");
    }

    public void StartGame()
    {
        GameManager.Instance.InitializeScene(sceneType.SCN_Vilage);
        GameManager.Instance.UnloadScene(sceneType.SCN_MainMenu);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenCredits(bool enable)
    {
        if(enable)
        {
            _credits.SetActive(true);
        }
        else
        {
            _credits.SetActive(false);
        }
    }
}
