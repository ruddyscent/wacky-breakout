using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    void Start()
    {
        AudioManager.Play(AudioClipName.GameLost);
    }

    public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Application.Quit();
    }

    public void HandleBackButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        SceneManager.LoadScene("MainMenu");
        Destroy(this);
    }
}
