using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneChangeHandler.Instance.LoadMainGame();
    }

    public void BackToMenu()
    {
        SceneChangeHandler.Instance.LoadMainMenu();
    }
}
