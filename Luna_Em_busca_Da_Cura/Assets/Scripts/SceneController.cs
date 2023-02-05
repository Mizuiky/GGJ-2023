using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum sceneType
{
    SCN_GamePlay,
    SCN_MainMenu,
    SCN_Vilage, 
    SCN_Forest
}
public class SceneController : MonoBehaviour
{
    public void LoadAdditiveScene(sceneType type)
    {
        SceneManager.LoadScene(type.ToString(), LoadSceneMode.Additive);
    }

    public void UnLoadAdditiveScene(sceneType type)
    {
        SceneManager.UnloadSceneAsync(type.ToString());
    }
}

