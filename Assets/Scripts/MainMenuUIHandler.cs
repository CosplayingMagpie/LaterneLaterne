using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneChangeHandler.Instance.LoadMainGame();
    }

    public void ShowCredits()
    {
        SceneChangeHandler.Instance.LoadCredits();
    }

    public void ExitGame()
    {
        SceneChangeHandler.Instance.EndScreen();
    }
}
