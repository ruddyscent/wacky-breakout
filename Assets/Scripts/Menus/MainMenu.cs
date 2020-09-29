using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Main:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
        }
    }

    public void HandlePlayButtonOnClickEvent()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void HandleHelpButtonOnClickEvent()
    {
        SceneManager.LoadScene("Help");
    }

    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
