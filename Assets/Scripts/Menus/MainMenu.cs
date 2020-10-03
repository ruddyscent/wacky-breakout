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
        AudioManager.Play(AudioClipName.MenuButtonClick);
        SceneManager.LoadScene("Gameplay");
    }

    public void HandleHelpButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        SceneManager.LoadScene("Help");
    }

    public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
