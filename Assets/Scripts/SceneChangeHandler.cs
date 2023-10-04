using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeHandler : MonoBehaviour
{

    public static SceneChangeHandler Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadMainMenu()
    {


        //Check the numbering of your project
        SceneManager.LoadScene(0);
    }

    public void LoadMainGame()
    {


        //Check the numbering of your project
        SceneManager.LoadScene(1);
    }

    public void LoadCredits()
    {


        //Check the numbering of your project
        SceneManager.LoadScene(2);
    }

    public void EndScreen()
    {


        //Check the numbering of your project
        SceneManager.LoadScene(3);
    }
}
