using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void HandleResumeButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        SceneManager.LoadScene("MainMenu");
        Destroy(this);
    }
}
